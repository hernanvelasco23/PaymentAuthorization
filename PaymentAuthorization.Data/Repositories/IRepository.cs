namespace PaymentAuthorization.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task UpdateAsync(TEntity entity);
        Task AddOrUpdateAsync(TEntity entity);
    }
}
