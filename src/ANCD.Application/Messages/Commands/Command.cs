using ANCD.Application.Messages.Commands;

namespace ANCD.Application.Messages.CommandsQueries
{
    public abstract class Command : Message, ICommand<CommandResult>
    {
    }
}
