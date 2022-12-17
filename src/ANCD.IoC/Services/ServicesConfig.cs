using ANCD.Domain.Services.Interfaces;
using ANCD.Infra.Services.Cache;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC.Services
{
    internal static class ServicesConfig
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            services.AddScoped<ICacheService, CacheService>();

            return services;
        }
    }
}
