using Microservice.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using Order.Application.Orders.Commands;
using Microservice.Core.ApiResult;
using Order.Application.Orders.DTOs;
using Order.Application.Orders.Queries;
namespace Order.API.Controllers;
//Compeleted soon
// Customer & Admin
[ApiController]
[Route("[controller]")]
public class OrdersController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher) : ControllerBase
{
    // Customer

    [HttpPost("[Action]")]
    public async Task<IActionResult> Create(CreateOrderDto dto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new CreateOrderCommand(dto), cancellationToken);
        return res.ToApiResult();
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> Cancel(CancelOrderDto dto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new CancelOrderCommand(dto), cancellationToken);
        return res.ToApiResult();
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> GetOrder(GetOrderDto dto, CancellationToken cancellationToken)
    {
        var res = await queryDispatcher.Dispatch(new GetOrderQuery(dto), cancellationToken);
        return res.ToApiResult();
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> GetOrders(GetOrdersDto dto, CancellationToken cancellationToken)
    {
        var res = await queryDispatcher.Dispatch(new GetOrdersQuery(dto), cancellationToken);
        return res.ToApiResult();
    }

    [HttpPost("[Action]")]
    public async Task<IActionResult> GetMyOrders(GetMyOrdersDto dto, CancellationToken cancellationToken)
    {
        var res = await queryDispatcher.Dispatch(new GetMyOrdersQuery(dto), cancellationToken);
        return res.ToApiResult();
    }

    // Admin

    [HttpPatch("[Action]")]
    public async Task<IActionResult> Confirm(ConfirmOrderDto dto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new ConfirmOrderCommand(dto), cancellationToken);
        return res.ToApiResult();
    }

    [HttpPatch("[Action]")]
    public async Task<IActionResult> ChangeStatus(ChangeOrderStatusDto dto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new ChangeOrderStatusCommand(dto), cancellationToken);
        return res.ToApiResult();
    }
}
