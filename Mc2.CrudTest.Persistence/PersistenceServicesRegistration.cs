using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<CommandDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBString")));

            services.AddDbContext<QueryDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DBString")));

            services.AddScoped<ICommandDbContext, CommandDbContext>();
            services.AddScoped<IQueryDbContext, QueryDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerEventRepository, CustomerEventRepository>();

            return services;
        }
    }

}
