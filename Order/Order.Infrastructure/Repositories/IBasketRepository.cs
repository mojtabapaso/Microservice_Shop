using Microservice.Core.Repository;
using Order.Domain.Entities;

namespace Order.Infrastructure.Repositories;

public interface IBasketRepository : IGenericRepository<Basket>
{
    Task<Basket?> GetActiveBasketWithItemsByUserId(long UserId);
    Task<Basket?> GetBasketWithAllItemsByUserIdAsync(long userId);
    Task<Basket?> GetBasketByUserIdAsync(long userId);
    Task<long> GetActiveBasketIdByUserId(long userId);
    Task<List<Basket>> GetExpiredBasketsAsync();
    Task<List<Basket>> GetBasketsByProductIdAsync(Guid productId,CancellationToken cancellationToken);

}
