using ANCD.Application.Commands.Validators;
using ANCD.IoC;
using FluentValidation.AspNetCore;

namespace ANCD.API.Extensions
{
    public static class ApiConfigExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegisterDoctorCommandValidator>());
            services.AddApiVersioning();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerConfig();
            services.AddInfraConfiguration();

            return services;
        }

        public static WebApplication ConfigureApp(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
                app.UseSwaggerConfig();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            return app;
        }
    }
}
