using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;

namespace Product.Application.Product.Commands;

public sealed record DeleteProductCommand(long ProductId) : ICommand<ServiceResult>;
