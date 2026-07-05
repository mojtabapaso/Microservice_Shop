using Microservice.Core;
using Microservice.Core.Middleware;
using Product.API.Grpc;
using Product.Application;
using Product.Infrastructure;
using Product.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddGrpc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlServer<DbContextProduct>(builder.Configuration);

builder.Services.AddDependencyScanning<InfrastructureAssemblyReference>();
builder.Services.AddApplicationMediator(typeof(ApplicationAssemblyReference).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())

{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();
// Grpc
app.MapGrpcService<ProductServiesServer>();
app.MapControllers();

app.Run();
