using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure.Application;
using Core.Infrastructure.Domain.Categories;
using Core.Infrastructure.Domain.Common;
using Core.Infrastructure.Domain.Receipts;
using Core.Infrastructure.Domain.Users;
using Core.WebAPI;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);
var ioc = new Container();
ioc.Options.EnableAutoVerification = true;
ioc.Options.DefaultLifestyle = Lifestyle.Scoped;

builder.Services.AddHellangProblemDetails();
builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddSimpleInjector(ioc, opt => opt.AddAspNetCore().AddControllerActivation());

ioc.RegisterInstance<ISqlConnectionFactory>(new SqliteConnectionFactory("Data source = core.db"));
ioc.Register<ISqlQueryExecutor, SqlQueryExecutor>();
ioc.Register<CoreDbContext>();
ioc.Register<DbContext, CoreDbContext>();

ioc.RegisterInstance<HttpUserProviderSettings>(
    builder.Configuration.GetSection("HttpUserProvider").Get<HttpUserProviderSettings>()!
);

ioc.Register<IUserProvider, HttpUserProvider>();

ioc.Register<IReceiptRepository, ReceiptRepository>();
ioc.Register<ICategoryRepository, CategoryRepository>();
ioc.Register<ICategoryProvider, CategoryRepository>();
ioc.Register(typeof(IQueryHandler<,>), typeof(IQueryHandler<,>).Assembly);
ioc.Register(typeof(ICommandHandler<>), typeof(ICommandHandler<>).Assembly);
ioc.Register(typeof(IValidator<>), typeof(ICommandHandler<>).Assembly);
ioc.RegisterConditional(typeof(IValidator<>), typeof(EmptyFluentRequestValidator<>), c => !c.Handled);
ioc.Register(typeof(IRequestValidator<>), typeof(FluentRequestValidator<>));
ioc.Register<IUnitOfWork, EntityFrameworkUnitOfWork>();
ioc.RegisterDecorator(typeof(IQueryHandler<,>), typeof(ValidationQueryHandlerDecorator<,>));
ioc.RegisterDecorator(typeof(ICommandHandler<>), typeof(UnitOfWorkCommandHandlerDecorator<>));
ioc.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));

ioc.Register<TestDataInitializer>(Lifestyle.Scoped);

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Expence Manager API", Version = "v1" });
    opt.TagActionsBy(apiDescr => new[] { apiDescr?.GroupName });
    opt.DocInclusionPredicate((name, api) => true);
});

var app = builder.Build();
app.Services.UseSimpleInjector(ioc);

using (var scope = AsyncScopedLifestyle.BeginScope(ioc))
{
    await ioc.GetInstance<TestDataInitializer>().Initialize();
}

app.UseHellangProblemDetails();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();