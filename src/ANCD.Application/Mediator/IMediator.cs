using ANCD.Application.Messages.CommandsQueries;

namespace ANCD.Application.Mediator
{
    public interface IMediator
    {
        Task<CommandResult> SendCommand<C>(C command) where C : Command;
    }
}
