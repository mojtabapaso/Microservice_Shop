using FluentValidation;
using Microservice.Contracts.Product.Protos;
using Microservice.Core;
using Microservice.Core.Middleware;
using Microsoft.IdentityModel.Tokens.Experimental;
using Order.Application;
using Order.Application.Consumers;
using Order.Infrastructure;
using Order.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

// ------------------------------------------------------------
// ASP.NET Core Services
// ------------------------------------------------------------
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// ------------------------------------------------------------
// Database
// ------------------------------------------------------------
builder.Services.AddSqlServer<DbContextBasket>(builder.Configuration);

builder.Services.AddDependencyScanning<InfrastructureAssemblyReference>();
// ------------------------------------------------------------
// MediatR
// ------------------------------------------------------------
builder.Services.AddApplicationMediator(typeof(ApplicationAssemblyReference).Assembly);
// ------------------------------------------------------------
// FluentValidation
// ------------------------------------------------------------
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyReference>();
builder.Services.AddPipelineBehaviors();
// RabbitMQ (MassTransit)
// ------------------------------------------------------------
builder.Services.AddRabbitMq(builder.Configuration, x =>
{
    x.AddConsumer<ProductPriceChangedConsumer>();
});
builder.Services.AddEventPublisher();
// ------------------------------------------------------------
// Redis
// ------------------------------------------------------------
builder.Services.AddRedis(builder.Configuration);
// Build Application
builder.Services.AddGrpcClient <ProductService.ProductServiceClient> (options =>
{
    options.Address = new Uri(builder.Configuration["Grpc"]);
});

// ------------------------------------------------------------
var app = builder.Build();
// ------------------------------------------------------------
// HTTP Request Pipeline
// ------------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();