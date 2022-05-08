using ANCD.Application.Messages.CommandsQueries;
using ANCD.Application.Messages.Queries;

namespace ANCD.Application.Mediator
{
    public interface IMediator
    {
        Task<CommandResult> SendCommand<C>(C command) where C : Command;

        Task<QueryResult<T>> SendQuery<Q, T>(Q query) where Q : Query<T>;
    }
}
