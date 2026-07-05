using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Product.Commands;
using Product.Application.Product.DTOs;

namespace Product.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController(ICommandDispatcher commandDispatcher) : ControllerBase
{
    [HttpPost("[Action]")]
    public async Task<IActionResult> Create(CreateProductDto createProductDto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new CreateProductCommand(createProductDto), cancellationToken);
        return res.ToApiResult();
    }
    [HttpPut("[Action]")]
    public async Task<IActionResult> Update(UpdateProductDto updateProductDto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new UpdateProductCommand(updateProductDto), cancellationToken);
        return res.ToApiResult();
    }
    [HttpDelete("[Action]")]
    public async Task<IActionResult> Delete([FromBody] long productId, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new DeleteProductCommand(productId), cancellationToken);
        return res.ToApiResult();
    }
    [HttpPatch("[Action]")]
    public async Task<IActionResult> Change(ChangeProductPriceDto changeProductPriceDto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new ChangeProductPriceCommand(changeProductPriceDto), cancellationToken);
        return res.ToApiResult();
    }
}
