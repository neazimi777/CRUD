using Mc2.CrudTest.Domain;
using Mc2.CrudTest.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Persistence
{
    public class CommandDbContext : DbContext, ICommandDbContext
    {
        public CommandDbContext(DbContextOptions<CommandDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerEventConfig).Assembly);
        }

        public DbSet<CustomerEvent> customerEvent { get; set; }
    }
}
