using Mc2.CrudTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public interface IQueryDbContext
    {
        DbSet<Customer> customer { get; set; }
    }
}
