using ANCD.Application.Messages.Commands;
using ANCD.Application.Messages.CommandsQueries;
using MediatR;

namespace ANCD.Application.Commands.Handlers
{
    public interface ICommandHandler<C> : IRequestHandler<C, CommandResult> where C : ICommand<CommandResult>
    {
    }
}
