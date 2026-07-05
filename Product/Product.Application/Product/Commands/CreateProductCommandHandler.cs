using Microservice.Core.ApiResult;
using Microservice.Core.EventPublisher;
using Microservice.Core.Mediator;
using Product.Application.Product.Events;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Commands;

//= = = = = = = = = = = = = = = = = = = = = = = = 

public sealed class CreateProductCommandHandler(IProductRepository productRepository , IEventContext eventContext)
            : ICommandHandler<CreateProductCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Product;
        var product = new Domian.Entities.Product(dto.Name, dto.Description, dto.Price, dto.Stock, dto.SKU);
        await productRepository.AddAsync(product);
        eventContext.Add(new ProductCreatedEvent(product.RowId));
        return ServiceResult.Success();
    }
}
//= = = = = = = = = = = = = = = = = = = = = = = = 