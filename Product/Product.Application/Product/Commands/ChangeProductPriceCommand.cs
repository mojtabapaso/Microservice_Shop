using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Product.Application.Product.DTOs;

namespace Product.Application.Product.Commands;

public sealed record ChangeProductPriceCommand(ChangeProductPriceDto ChangeProductPriceDto) : ICommand<ServiceResult>;
