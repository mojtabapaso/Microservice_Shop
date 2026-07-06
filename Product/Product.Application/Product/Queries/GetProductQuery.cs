using Microservice.Core.ApiResult;
using Microservice.Core.Mediator;
using Product.Application.Product.DTOs;
using Product.Domain.Documents;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Queries;

public sealed record GetProductQuery(GetProductDto GetProductDto) : IQuery<ServiceResult<Domain.Entities.Product>>;
public sealed record GetProductByPublicIdQuery(GetProductByPublicIdDto GetProductByPublicIdDto) : IQuery<ServiceResult<ProductDocument>>;

public class GetProductQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductQuery, ServiceResult<Domain.Entities.Product>>
{
    public async Task<ServiceResult<Domain.Entities.Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var result = await productRepository.FindByIdAsync(request.GetProductDto.ProductId);
        if (result is null)
        {
            return ServiceResult<Domain.Entities.Product>.NotFound("Product not found");
        }
        return ServiceResult<Domain.Entities.Product>.Success(result);
    }
}

public class GetProductByPublicIdQueryHandler(IProductMongoRepository productMongoRepository) : IQueryHandler<GetProductByPublicIdQuery, ServiceResult<ProductDocument>>
{
    public async Task<ServiceResult<ProductDocument>> Handle(GetProductByPublicIdQuery request, CancellationToken cancellationToken)
    {
        var result = await productMongoRepository.GetByIdAsync(request.GetProductByPublicIdDto.ProductId, cancellationToken);
        if(result is null)
        {
            return ServiceResult<ProductDocument>.NotFound("Product not found");
        }
        return ServiceResult<ProductDocument>.Success(result);
    }
}