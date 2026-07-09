using Microservice.Core.ApiResult;
using Microservice.Core.EventPublisher;
using Microservice.Core.Mediator;
using Product.Application.Product.Events;
using Product.Domain.ValueObjects;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Commands;

//= = = = = = = = = = = = = = = = = = = = = = = = 
public sealed class UpdateProductCommandHandler(IProductRepository productRepository, IEventContext eventContext)
    : ICommandHandler<UpdateProductCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.Product.ProductId);
        if (product is null)
            return ServiceResult.Failure();
        var dto = request.Product;
        product.UpdateInformation(new ProductName(dto.Name), dto.Description, new Money(dto.Price, Currency.IRR), dto.SKU);
        productRepository.Update(product);
        eventContext.Add(new ProductUpdatedEvent(product.RowId));

        //await _productRepository.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success();
    }
}
//= = = = = = = = = = = = = = = = = = = = = = = = 