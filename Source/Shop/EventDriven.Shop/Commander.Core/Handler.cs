using Commander.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commander.Core
{
    public class Handler : IHandler
    {
        private readonly IMediator mediator;
        public Handler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public Task RaiseEvent<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken)) where TEvent : IEvent
        {
            return mediator.Publish(@event, cancellationToken);
        }

        public Task<CommandResult> Send<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken)) 
            where TCommand : ICommand<CommandResult>
        {
            return this.mediator.Send(command, cancellationToken);
        }

        public Task Validate<T>(T entity) where T : IValidatable
        {
            throw new NotImplementedException();
        }
    }
}
