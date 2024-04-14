using Microsoft.EntityFrameworkCore;

namespace PaymentAuthorization.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly PaymentAuthorizationDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(PaymentAuthorizationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddOrUpdateAsync(TEntity entity)
        {
            await AddAsync(entity);
        }
    }
}
