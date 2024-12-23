using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SYN.Domain.Options;

namespace SYN.Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            return services;
        }
    }
}
