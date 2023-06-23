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

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();
app.Run();