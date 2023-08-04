using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Mc2.CrudTest.DomainService
{
    public static class DomainServiceServicesRegistration
    {
        public static IServiceCollection ConfigureDomainServiceServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);

            return services;

        }
    }
}
