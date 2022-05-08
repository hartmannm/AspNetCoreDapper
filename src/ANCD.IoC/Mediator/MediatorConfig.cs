using ANCD.Application.Commands;
using ANCD.Application.Commands.Handlers;
using ANCD.Application.DTOs;
using ANCD.Application.Messages.CommandsQueries;
using ANCD.Application.Messages.Queries;
using ANCD.Application.Queries;
using ANCD.Application.Queries.Handlers;
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
            services.AddScoped<IRequestHandler<RegisterPatientCommand, CommandResult>, RegisterPatientCommandHandler>();
            services.AddScoped<IRequestHandler<ScheduleMedicalExamCommand, CommandResult>, ScheduleMedicalExamCommandHandler>();
            services.AddScoped<IRequestHandler<AccomplishMedicalExamCommand, CommandResult>, AccomplishMedicalExamCommandHandler>();

            services.AddScoped<IRequestHandler<GetPatientByIdQuery, QueryResult<PatientDTO>>, GetPatientByIdQueryHandler>();

            return services;
        }
    }
}
