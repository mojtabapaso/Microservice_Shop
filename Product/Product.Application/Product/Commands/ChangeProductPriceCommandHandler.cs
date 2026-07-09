using Microservice.Contracts.IntegrationEvent;
using Microservice.Core.ApiResult;
using Microservice.Core.EventPublisher;
using Microservice.Core.Mediator;
using Product.Domain.ValueObjects;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Commands;

//= = = = = = = = = = = = = = = = = = = = = = = = 
public sealed class ChangeProductPriceCommandHandler(IProductRepository productRepository, IEventContext eventContext) : ICommandHandler<ChangeProductPriceCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(ChangeProductPriceCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.ChangeProductPriceDto.ProductId);
        if (product is null)
            return ServiceResult.Failure();
        product.ChangePrice(new Money(request.ChangeProductPriceDto.NewPrice, Currency.IRR));
        productRepository.Update(product);
        eventContext.Add(new ProductPriceChangedEvent(product.RowId, request.ChangeProductPriceDto.NewPrice));

        //await productRepository.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success();
    }
}
//= = = = = = = = = = = = = = = = = = = = = = = = 