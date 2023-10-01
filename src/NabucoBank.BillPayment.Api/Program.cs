using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;
using NabucoBank.BillPayment.Application.ExternalsApi;
using NabucoBank.BillPayment.Application.Interfaces;
using NabucoBank.BillPayment.Application.Services;
using NabucoBank.BillPayment.CrossCutting.AutoMapper;
using NabucoBank.BillPayment.CrossCutting.Config;
using NabucoBank.BillPayment.Domain.Interfaces;
using NabucoBank.BillPayment.Domain.Interfaces.Repositories;
using NabucoBank.BillPayment.Domain.Services;
using NabucoBank.BillPayment.Infrastructure.Repositories;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

const string _pathBase = "/billpayment-api";
const string _apiName = "NabucoBank - BillPayment Api";

builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", false);

builder.Services.AddTransient<IDbConnection>((sql) => new MySqlConnection(builder.Configuration.GetConnectionString("NabucoBank")));

//Repository
builder.Services.AddTransient<IBilletRepository, BilletRepository>();

//App
builder.Services.AddScoped<IBilletServiceApp, BilletServiceApp>();

//Externals Apis
builder.Services.AddScoped<IAccountApi, AccountApi>();

//Domain
builder.Services.AddScoped<IBilletService, BilletService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
DbMapping.InitializeMapping();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = _apiName,
        Version = "v1.0.0"
    });
    c.CustomSchemaIds(x => x.FullName);
});

var app = builder.Build();

app.UsePathBase(new PathString(_pathBase));
app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"{_pathBase}/swagger/v1/swagger.json", _apiName);
    c.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();