using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Application.Common;
using Core.Application.Receipts.GetReceipt;
using Core.Infrastructure.Domain.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.Register(c => new SqliteConnectionFactory("Data source = test.db")).As<ISqlConnectionFactory>();
    containerBuilder.RegisterType<SqlQueryExecutor>().As<ISqlQueryExecutor>();
    containerBuilder.RegisterType<GetReceiptQueryHandler>().As<IQueryHandler<GetReceiptQuery, ReceiptDto>>();
});

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();