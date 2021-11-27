using ComputerTechnicianBackend.Data.EF.SQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ComputerTechnicianBackend.Data.Services.Abstraction
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(long? id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> InsertAsync(TEntity newEntity);
        Task<TEntity> UpdateAsync(TEntity newEntity);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
    {
        private ComputerTechnicianDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;

        protected BaseService(ComputerTechnicianDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(long? id, CancellationToken cancellationToken)
        {
            return await dbSet.FindAsync(new object[]{id}, cancellationToken);
        }

        public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<TEntity> InsertAsync(TEntity newEntity)
        {
            await dbSet.AddAsync(newEntity);
            await dbContext.SaveChangesAsync();
            return newEntity;
        }

        public async Task<TEntity> UpdateAsync(TEntity newEntity)
        {
            if (dbContext.Entry(newEntity).State == EntityState.Detached)
            {
                dbSet.Attach(newEntity);
            }

            dbContext.ChangeTracker.DetectChanges();
            await dbContext.SaveChangesAsync();
            return newEntity;
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken)
        {
            var entity = await GetAsync(id, cancellationToken);
            if (entity != null)
            {
                dbSet.Remove(entity);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
