using Microsoft.AspNetCore.Mvc;
using Order.Application.Basket.Commands;
using Order.Application.Basket.DTOs;
using Order.Application.Basket.Queries;
using Sheard.ApiResult;
using Sheard.Mediator;

namespace Order.API.Controllers;

[ApiController]
[Route("api/v1/basket")]
public class BasketController(IQueryDispatcher queryDispatcher,ICommandDispatcher commandDispatcher) : ControllerBase
{
    

    [HttpGet("{userId:long}")]
    public async Task<IActionResult> Get(long userId)
    {
        
        var result = await queryDispatcher.Dispatch(new GetOrCreateBasketQuery(userId));
        return result.ToApiResult();
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddBasketItemDTO dto)
    {
        var result = await commandDispatcher.Dispatch(new AddItemToBasketCommand(dto.UserId, dto.ProductId, dto.Quantity, dto.UnitPrice));
        return result.ToApiResult();
    }

    [HttpPut("/{userId:long}/items/{productId:long}/quantity/{newQuantity:int}/")]
    public async Task<IActionResult> Update(long userId, long productId, int newQuantity)
    {
        var result = await commandDispatcher.Dispatch(new UpdateBasketItemQuantityCommand(userId, productId, newQuantity));
        return result.ToApiResult();
    }

    [HttpDelete("/{userId:long}/items/{productId:long}")]
    public async Task<IActionResult> DeleteOne(long userId,long productId)
    {
        var result = await commandDispatcher.Dispatch(new RemoveBasketItemCommand(userId, productId));
        return result.ToApiResult();
    }

    [HttpDelete("/{userId:long}")]
    public async Task<IActionResult> DeleteAll(long userId)
    {
        var result = await commandDispatcher.Dispatch(new ClearBasketCommand(userId));
        return result.ToApiResult();
    }

}
