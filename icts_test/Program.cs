using AutoMapper;
using Domain.Services;
using icts_test.Domain.Interfaces;
using icts_test.Domain.Interfaces.Generics;
using icts_test.Domain.Interfaces.InterfaceServices;
using icts_test.Entities.Entities;
using icts_test.Infrastructure.Configuration;
using icts_test.Infrastructure.Repository;
using icts_test.Infrastructure.Repository.Repositories;
using icts_test.WebAPIs.Models;
using icts_test.WebAPIs.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ConfigServices

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ContextBase>(options =>
              options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ContextBase>();

// Interface e repositorio
builder.Services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerics<>));
builder.Services.AddSingleton<ICategory, RepositoryCategory>();
builder.Services.AddSingleton<IProduct, RepositoryProduct>();

// Serviço dominio
builder.Services.AddSingleton<IServiceCategory, ServiceCategory>();
builder.Services.AddSingleton<IServiceProduct, ServiceProduct>();

// JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Teste.Security.Bearer",
            ValidAudience = "Teste.Security.Bearer",
            IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context => 
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return Task.CompletedTask;
            },
            OnTokenValidated = context => 
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return Task.CompletedTask;
            }
        };
    });

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<CategoryViewModel, Category>();
    cfg.CreateMap<Category, CategoryViewModel>();

    cfg.CreateMap<ProductViewModel, Product>();
    cfg.CreateMap<Product, ProductViewModel>();
});

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
