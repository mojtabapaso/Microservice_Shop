using Order.Domain.Entities;
using Sheard.Repository;

namespace Order.Infrastructure.Persistence.Repositories;

public interface IBasketRepository : IGenericRepository<Basket>
{
    Task<Basket?> GetActiveBasketWithItemsByUserId(long UserId);
    Task<Basket?> GetBasketWithAllItemsByUserIdAsync(long userId);
    Task<Basket?> GetBasketByUserIdAsync(long userId);
    Task<long> GetActiveBasketIdByUserId(long userId);
    Task<List<Basket>> GetExpiredBasketsAsync();

}
