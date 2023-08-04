using Mc2.CrudTest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CommandDbContext _dbContext;

        public GenericRepository(CommandDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _dbContext.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public IQueryable<T> QueryAllAsNoTracking()
        {
            return _dbContext.Set<T>().AsNoTracking();
        }
    }
}
