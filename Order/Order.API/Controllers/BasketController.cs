using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Basket.Commands;
using Order.Application.Basket.DTOs;
using Order.Application.Basket.Queries;

namespace Order.API.Controllers;

[ApiController]
[Route("api/v1/basket")]
public class BasketController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : ControllerBase
{


    [HttpGet("{userId:long}")]
    public async Task<IActionResult> Get(long userId, CancellationToken cancellationToken)
    {

        var result = await queryDispatcher.Dispatch(new GetOrCreateBasketQuery(userId), cancellationToken);
        return result.ToApiResult();
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddBasketItemDTO dto, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new AddItemToBasketCommand(dto.UserId, dto.ProductId, dto.Quantity, dto.UnitPrice), cancellationToken);
        return result.ToApiResult();
    }

    [HttpPut("/{userId:long}/items/{productId:long}/quantity/{newQuantity:int}/")]
    public async Task<IActionResult> Update(long userId, long productId, int newQuantity, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new UpdateBasketItemQuantityCommand(userId, productId, newQuantity), cancellationToken);
        return result.ToApiResult();
    }

    [HttpDelete("/{userId:long}/items/{productId:long}")]
    public async Task<IActionResult> DeleteOne(long userId, long productId, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new RemoveBasketItemCommand(userId, productId), cancellationToken);
        return result.ToApiResult();
    }

    [HttpDelete("/{userId:long}")]
    public async Task<IActionResult> DeleteAll(long userId, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new ClearBasketCommand(userId), cancellationToken);
        return result.ToApiResult();
    }

}
