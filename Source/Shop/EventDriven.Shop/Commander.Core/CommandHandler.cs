using Commander.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commander.Core
{
    public abstract class CommandHandler<TCommand> : ICommandHandler<TCommand> where TCommand : ICommand<CommandResult>
    {
        private List<IEvent> events;
        protected IHandler handler;
        public CommandHandler(IHandler handler)
        {
            events = new List<IEvent>();
            this.handler = handler;
        }

        public async Task<CommandResult> Handle(TCommand request, CancellationToken cancellationToken)
        {
            if (request.Invalid)
                return new CommandResult(false);

            var result = await HandleCommandAsync(request);

            if (events.Any())
            {
                List<Task> eventsTasks = new List<Task>();

                foreach (var @event in events)
                {
                    var domainEvent = new DomainEvent(@event);
                    eventsTasks.Add(handler.RaiseEvent(domainEvent));
                }

                await Task.WhenAll(eventsTasks);
            }                

            return result;
        }

        protected Task AddEventsAsync(params IEvent[] @event)
        {
            events.AddRange(@event);

            return Task.CompletedTask;
        }

        public abstract Task<CommandResult> HandleCommandAsync(TCommand @command);
    }
}
