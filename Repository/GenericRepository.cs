using employee_app.Entities;
using Microsoft.EntityFrameworkCore;

namespace employee_app.Repository
{

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(int id, TEntity entity);
        Task DeleteAsync(int id);
        Task<TEntity> GetByIdAsync(int id, string includeProperties = "");
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class , IEntity
    {
        private readonly ApplicationDbContext _dbContext;
 
        public GenericRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id,TEntity entity)
        {
            var entityExists = await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if(entityExists is not null)
            {
                entity.Id = entityExists.Id;
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync();
            }
          
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync( x => x.Id == id );
            if (entity is not null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<TEntity> GetByIdAsync(int id , string includeProperties = "")
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                query = query.Include(includeProperties); 
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        }
    }
}
