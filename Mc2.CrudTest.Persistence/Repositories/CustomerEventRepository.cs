using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Domain.Repositories;

namespace Mc2.CrudTest.Persistence.Repositories
{
    public class CustomerEventRepository : GenericRepository<CustomerEvent>, ICustomerEventRepository
    {
        public CustomerEventRepository(CommandDbContext dbContext) : base(dbContext)
        {
        }
    }
}
