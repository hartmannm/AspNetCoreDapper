using ANCD.Application.Messages.Queries;
using MediatR;

namespace ANCD.Application.Queries.Handlers
{
    public interface IQueryHandler<Q, T> : IRequestHandler<Q, QueryResult<T>> where Q : IQuery<QueryResult<T>>
    {
    }
}
