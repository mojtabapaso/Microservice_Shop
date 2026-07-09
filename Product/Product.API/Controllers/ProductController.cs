using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Product.Commands;
using Product.Application.Product.DTOs;
using Product.Application.Product.Queries;

namespace Product.API.Controllers;

[ApiController]
//[Authorize(Roles = "Admin")]
[Route("[controller]")]
public class ProductController(ICommandDispatcher commandDispatcher,IQueryDispatcher queryDispatcher) : ControllerBase
{
    //Admin role
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
    public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new DeleteProductCommand(deleteProductDto), cancellationToken);
        return res.ToApiResult();
    }
    [HttpPatch("[Action]")]
    public async Task<IActionResult> Change(ChangeProductPriceDto changeProductPriceDto, CancellationToken cancellationToken)
    {
        var res = await commandDispatcher.Dispatch(new ChangeProductPriceCommand(changeProductPriceDto), cancellationToken);
        return res.ToApiResult();
    }
    [HttpPost("[Action]")]
    public async Task<IActionResult> GetProduct(GetProductDto  getProductDto, CancellationToken cancellationToken)
    {
        var res = await queryDispatcher.Dispatch(new GetProductQuery(getProductDto), cancellationToken);
        return res.ToApiResult();
    }
    //customer
    [AllowAnonymous]
    [HttpPost("[Action]")]
    public async Task<IActionResult> GetProductByPublicId(GetProductByPublicIdDto  getProductByPublicIdDto, CancellationToken cancellationToken)
    {
        var res = await queryDispatcher.Dispatch(new GetProductByPublicIdQuery(getProductByPublicIdDto), cancellationToken);
        return res.ToApiResult();
    }
}
