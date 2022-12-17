using ANCD.IoC.Data;
using ANCD.IoC.Map;
using ANCD.IoC.Mediator;
using ANCD.IoC.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureRedis(configuration);
            services.ConfigureMediator();
            services.ConfigureMapper();
            services.ConfigureAppServices();
            services.ConfigureRepositories(configuration);

            return services;
        }
    }
}
