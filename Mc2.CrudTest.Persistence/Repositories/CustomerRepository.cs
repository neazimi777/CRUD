using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
