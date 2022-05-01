using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Infra.Data;
using ANCD.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC.Data
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDataManager, DataManager>();

            return services;
        }
    }
}
