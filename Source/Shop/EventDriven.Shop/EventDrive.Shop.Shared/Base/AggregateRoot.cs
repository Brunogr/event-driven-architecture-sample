using Commander.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventDrive.Shop.Shared.Base
{
    public abstract class AggregateRoot
    {
        public AggregateRoot()
        {
            DomainEvents = new List<IEvent>();
        }
        public List<IEvent> DomainEvents { get; private set; }

        protected void AddEvent(IEvent @event)
        {
            this.DomainEvents.Add(@event);
        }

    }
}
