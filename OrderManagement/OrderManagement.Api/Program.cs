using FluentValidation;
using FluentValidation.AspNetCore;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Mappings;
using OrderManagement.Application.Services;
using OrderManagement.Application.Validators;
using OrderManagement.Infrastructure;
using OrderManagement.Infrastructure.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Read from appsettings.json
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Host.UseSerilog(); // Add Serilog

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();

// Register Logging Service
builder.Services.AddScoped(typeof(ILogService<>), typeof(LogService<>));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();