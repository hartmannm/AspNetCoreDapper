using Microsoft.AspNetCore.Mvc;

namespace ANCD.API.Extensions
{
    public static class VersionExtensions
    {
        public static IServiceCollection ConfigureVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
            });

            return services;
        }
    }
}
