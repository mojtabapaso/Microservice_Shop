using Microservice.Contracts.Product.Protos;
using Grpc.Core;
using Product.Infrastructure.Repositories;

namespace Product.API.Grpc;

public class ProductServiesServer(IProductRepository productRepository) : ProductService.ProductServiceBase 
{
    public override Task<ChangeProductResponceDto> ChangeProduct(ChangeProductRequestDto request, ServerCallContext context)
    {
        return Task.FromResult(new ChangeProductResponceDto { IsApplied = true });
        //return base.ChangeProduct(request, context);
    }
    public async override Task<GetProductDataResponceDto> GetProductData(GetProductDataRequestDto request, ServerCallContext context)
    {
        var product = await productRepository.FindByRowIdAsync(Guid.Parse(request.ProductId));
        var res = new GetProductDataResponceDto { Price = product.Price };
        return res;
    }
}