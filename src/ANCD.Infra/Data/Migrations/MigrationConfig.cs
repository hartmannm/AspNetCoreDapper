using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ANCD.Infra.Data.Migrations
{
    public static class MigrationConfig
    {
        public static IServiceCollection ConfigureMigrations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(configuration.GetConnectionString("DatabaseConnection"))
                    .ScanIn(typeof(MigrationConfig).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

            return services;
        }
    }
}
