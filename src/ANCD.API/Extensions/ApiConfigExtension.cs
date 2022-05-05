using ANCD.API.Database;
using ANCD.Application.Commands.Validators;
using ANCD.IoC;
using FluentValidation.AspNetCore;

namespace ANCD.API.Extensions
{
    public static class ApiConfigExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterDoctorCommandValidator>());
            services.AddApiVersioning();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
            services.AddInfraConfiguration(configuration);

            return services;
        }

        public static WebApplication ConfigureApp(this WebApplication app, IConfiguration configuration)
        {
            if (app.Environment.IsDevelopment())
                app.UseSwaggerConfig();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            AppDatabaseHandler.EnsureDatabase(configuration);
            app.Migrate();

            return app;
        }
    }
}
