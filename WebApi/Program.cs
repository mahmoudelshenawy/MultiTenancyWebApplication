using Application.Interfaces;
using Application.DependencyInjection;
using Core.Settings;
using Infrastructure.Services;
using Infrastructure.Extensions;
using Infrastructure.DependencyInjection;
using Infrastructure;
using FluentValidation.AspNetCore;
using Application.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.Configure<TenantSettings>(configuration.GetSection(nameof(TenantSettings)));

builder.Services.AddControllers()
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<DepartmentValidator>());

builder.Services.AddValidatorsFromAssemblyContaining<DepartmentValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.InjectApplicationService()
    .InjectInfrastructureServices();

builder.Services.AddAndMigrateTenantDatabases(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
