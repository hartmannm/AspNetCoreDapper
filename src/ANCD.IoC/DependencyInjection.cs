using ANCD.IoC.Data;
using ANCD.IoC.Map;
using ANCD.IoC.Mediator;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraConfiguration(this IServiceCollection services)
        {
            services.ConfigureMediator();
            services.ConfigureMapper();
            services.ConfigureRepositories();

            return services;
        }
    }
}
