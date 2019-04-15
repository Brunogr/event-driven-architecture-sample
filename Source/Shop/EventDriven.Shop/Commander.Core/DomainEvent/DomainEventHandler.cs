using Commander.MessageBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core
{
    internal class DomainEventHandler : EventHandler<DomainEvent>
    {
        private readonly IMessageBus messageBus;
        public DomainEventHandler(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }
        public async override Task HandleEvent(DomainEvent @event)
        {
            await this.messageBus.PublishAsync(@event.Event);
        }
    }
}
