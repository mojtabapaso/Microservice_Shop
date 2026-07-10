using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Basket.Commands;
using Order.Application.Basket.DTOs;
using Order.Application.Basket.Queries;

namespace Order.API.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("api/v1/basket")]
public class BasketController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : ControllerBase
{
    [HttpGet("[Action]")]
    public async Task<IActionResult> Get(GetBasketDTO getBasketDTO, CancellationToken cancellationToken)
    {
        var result = await queryDispatcher.Dispatch(new GetOrCreateBasketQuery(getBasketDTO), cancellationToken);
        return result.ToApiResult();
    }
    [HttpPost("Add")]
    public async Task<IActionResult> Add(AddBasketItemDTO addBasketItemDTO, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new AddItemToBasketCommand(addBasketItemDTO), cancellationToken);
        return result.ToApiResult();
    }

    [HttpPut("[Action]")]
    public async Task<IActionResult> Update(UpdateBasketItemQuantityDTO basketItemQuantityDTO, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new UpdateBasketItemQuantityCommand(basketItemQuantityDTO), cancellationToken);
        return result.ToApiResult();
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> RemoveBasketItem(RemoveBasketItemDTO removeBasketItemDTO, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new RemoveBasketItemCommand(removeBasketItemDTO), cancellationToken);
        return result.ToApiResult();
    }

    [HttpDelete("[Action]")]
    public async Task<IActionResult> DeleteAll(ClearBasketDTO clearBasketDTO, CancellationToken cancellationToken)
    {
        var result = await commandDispatcher.Dispatch(new ClearBasketCommand(clearBasketDTO), cancellationToken);
        return result.ToApiResult();
    }

}
