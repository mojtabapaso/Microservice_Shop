using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Basket.DTOs;

namespace Order.Application.Basket.Commands;

public record AddItemToBasketCommand(AddBasketItemDTO AddBasketItemDTO) : ICommand<ServiceResult>;
