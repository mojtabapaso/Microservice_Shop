using Microservice.Core;
using Microservice.Core.Extensions;
using Notification.Application;
using Notification.Infrastructure;
using Notification.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<DbContextNotification>(builder.Configuration);
builder.Services.AddApplicationMediator(typeof(ApplicationAssemblyReference).Assembly);
builder.Services.AddDependencyScanning<InfrastructureAssemblyReference>();
//builder.Services.AddRabbitMq(builder.Configuration);
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
