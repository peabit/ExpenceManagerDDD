using Core.Application.Common;
using Core.Domain.AggregatesModel.Categories;
using Core.Domain.AggregatesModel.Receipts;
using Core.Domain.Users;
using Core.Infrastructure.Application;
using Core.Infrastructure.Domain.Categories;
using Core.Infrastructure.Domain.Common;
using Core.Infrastructure.Domain.Receipts;
using Core.Infrastructure.Domain.Users;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SimpleInjector;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);
var ioc = new Container();
ioc.Options.EnableAutoVerification = false;
ioc.Options.DefaultLifestyle = Lifestyle.Scoped;

builder.Services.AddHellangProblemDetails();
builder.Services.AddControllers();
builder.Services.AddSimpleInjector(ioc, opt => opt.AddAspNetCore().AddControllerActivation());

ioc.RegisterInstance<ISqlConnectionFactory>(new SqliteConnectionFactory("Data source = test.db"));
ioc.Register<ISqlQueryExecutor, SqlQueryExecutor>();
ioc.Register<CoreDbContext>();
ioc.Register<DbContext, CoreDbContext>();
ioc.Register<IUserProvider, FakeUserProvider>();
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

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Expence Manager API", Version = "v1" });
    opt.TagActionsBy(apiDescr => new[] { apiDescr?.GroupName });
    opt.DocInclusionPredicate((name, api) => true);
});

var app = builder.Build();

app.UseHellangProblemDetails();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();