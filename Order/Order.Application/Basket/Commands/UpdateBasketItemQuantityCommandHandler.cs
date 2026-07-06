using MediatR;
using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Order.Application.Basket.Events;
using Order.Infrastructure.Repositories;

namespace Order.Application.Basket.Commands;

/// <summary>
/// هندلر مربوط به بروزرسانی تعداد یک آیتم در سبد خرید
/// </summary>
public class UpdateBasketItemQuantityCommandHandler(IBasketRepository basketRepository,IMediator mediator)
    : ICommandHandler<UpdateBasketItemQuantityCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateBasketItemQuantityCommand request,CancellationToken cancellationToken)
    {
        var basket = await basketRepository.GetActiveBasketWithItemsByUserId(request.UserId);
        if (basket is not null)
        {
            basket.UpdateQuantity(request.ProductId,request.NewQuantity);
        }
        await mediator.Send(new RestoreCacheBasketEvent(request.UserId),cancellationToken);
        return ServiceResult.Success();
    }
}