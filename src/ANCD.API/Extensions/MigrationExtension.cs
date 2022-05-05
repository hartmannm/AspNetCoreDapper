using FluentMigrator.Runner;

namespace ANCD.API.Extensions
{
    public static class MigrationExtension
    {   
        public static IApplicationBuilder Migrate(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp(20220504220000);

            return app;
        }
    }
}
