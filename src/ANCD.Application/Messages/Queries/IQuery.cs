using MediatR;

namespace ANCD.Application.Messages.Queries
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
