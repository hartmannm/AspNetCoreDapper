using ANCD.Application.Commands;
using ANCD.Application.Commands.Handlers;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Infra.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ANCD.IoC.Mediator
{
    internal static class MediatorConfig
    {
        public static IServiceCollection ConfigureMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<Application.Mediator.IMediator, MediatRMediator>();

            services.AddScoped<IRequestHandler<RegisterDoctorCommand, CommandResult>, RegisterDoctorCommandHandler>();

            return services;
        }
    }
}
