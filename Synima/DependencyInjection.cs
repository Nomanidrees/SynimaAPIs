using SYN.Application;
using SYN.Domain;
using SYN.Infrastructure;

namespace Synima
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSynAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDI()
                .AddInfrastructureDI(configuration)
                .AddDomainDI(configuration);

            return services;
        }
    }
}
