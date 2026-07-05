using Microservice.Core.ApiResult;
using Microservice.Core.EventPublisher;
using Microservice.Core.Mediator;
using Product.Application.Product.Events;
using Product.Infrastructure.Repositories;

namespace Product.Application.Product.Commands;

//= = = = = = = = = = = = = = = = = = = = = = = = 
public sealed class DeleteProductCommandHandler(IProductRepository productRepository, IEventContext  eventContext) : ICommandHandler<DeleteProductCommand, ServiceResult>
{
    public async Task<ServiceResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await productRepository.FindByIdAsync(request.ProductId);
        if (product is null)
            return ServiceResult.Failure();
        productRepository.Remove(product);
        eventContext.Add(new ProductDeletedEvent(product.RowId));
        //await productRepository.SaveChangesAsync(cancellationToken);
        return ServiceResult.Success();
    }
}
//= = = = = = = = = = = = = = = = = = = = = = = = 