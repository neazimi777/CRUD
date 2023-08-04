using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public interface ICommandDbContext
    {
        DbSet<CustomerEvent> customerEvent { get; set; }
    }
}
