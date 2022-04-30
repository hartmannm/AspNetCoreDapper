using ANCD.Application.Messages.CommandsQueries;
using MediatR;

namespace ANCD.Infra.Mediator
{
    public class MediatRMediator : Application.Mediator.IMediator
    {
        private readonly IMediator _mediator;

        public MediatRMediator(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CommandResult> SendCommand<C>(C command) where C : Command
        {
            return await _mediator.Send(command);
        }
    }
}
