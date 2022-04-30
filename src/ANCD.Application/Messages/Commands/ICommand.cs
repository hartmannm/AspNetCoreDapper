using MediatR;

namespace ANCD.Application.Messages.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }
}
