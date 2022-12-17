using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC.Data
{
    public static class DatabaseConfigurations
    {
        public static IServiceCollection ConfigureRedis(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddStackExchangeRedisCache(options =>
            {
                options.InstanceName = "AspNetCoreDapper";
                options.Configuration = configuration.GetConnectionString("RedisConnection");
            });

            return services;
        }
    }
}
