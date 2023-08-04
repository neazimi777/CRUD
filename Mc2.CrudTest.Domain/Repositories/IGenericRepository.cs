using Microsoft.EntityFrameworkCore.Storage;

namespace Mc2.CrudTest.Domain.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        public Task SaveAsync();
        Task<IDbContextTransaction> BeginTransaction();
        public IQueryable<T> QueryAllAsNoTracking();
    }
}
