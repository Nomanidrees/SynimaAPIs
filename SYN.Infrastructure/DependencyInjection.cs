using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SYN.Domain.Interfaces;
using SYN.Domain.Options;
using SYN.Infrastructure.Data;
using SYN.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYN.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<SynDBContext>((provider, options) =>
            {
                options.UseSqlServer(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.dbcs);
                //options.UseSqlServer(configuraiton.GetConnectionString("dbcs"));
            });
            services.AddScoped<IEmployeeRepositories, EmployeeRepositories>();
            return services;
        }
    }
}
