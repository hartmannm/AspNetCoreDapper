using ANCD.Application.Data;
using ANCD.Application.Data.Repositories;
using ANCD.Infra.Data;
using ANCD.Infra.Data.Migrations;
using ANCD.Infra.Data.Repositories;
using ANCD.Infra.Data.Repositories.Cache;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.IoC.Data
{
    internal static class RepositoriesConfiguration
    {
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbContext, DbContext>();
            services.ConfigureMigrations(configuration);
            services.AddScoped<DoctorRepository>();
            services.AddScoped<IDoctorRepository, CacheDoctorRepositoryDecorator<DoctorRepository>>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<IPatientRepository, CachePatientRepositoryDecorator<PatientRepository>>();
            services.AddScoped<IMedicalExamRepository, MedicalExamRepository>();
            services.AddScoped<IDataManager, DataManager>();

            return services;
        }
    }
}
