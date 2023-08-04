using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public class QueryDbContext : DbContext, IQueryDbContext
    {
        public QueryDbContext(DbContextOptions<QueryDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfig).Assembly);
        }

        public DbSet<Customer> customer { get; set; }
    }
}
