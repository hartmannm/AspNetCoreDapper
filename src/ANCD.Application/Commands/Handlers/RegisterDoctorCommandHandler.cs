using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Commands.Handlers
{
    public class RegisterDoctorCommandHandler : ICommandHandler<RegisterDoctorCommand>
    {
        public async Task<CommandResult> Handle(RegisterDoctorCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return CommandResult.Success();   
        }
    }
}
