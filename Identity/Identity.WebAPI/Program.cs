using Identity.WebAPI;
using Identity.WebAPI.DataAccess;
using Identity.WebAPI.Model;
using Identity.WebAPI.Services.TokenSender;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite("Data source = users.db"));

builder.Services.AddScoped<ITokenSender, FakeTokenSender>();

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    TestDataInitializer.Initialize(scope.ServiceProvider.GetRequiredService<UserManager<User>>());
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();