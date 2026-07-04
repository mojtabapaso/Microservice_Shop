namespace Microservice.Core.Repository;

public interface IGenericRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity);
    void Remove(TEntity entity);
    void Remove(long Id);
    TEntity FindById(long id);
    Task<TEntity> FindByIdAsync(long id);
    List<TEntity> GetAll();
    Task<List<TEntity>> GetAllAsync();
}
