using Commander.Abstractions;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventDriven.Shop.Shared.Base
{
    public abstract class AggregateRoot
    {
        public AggregateRoot()
        {
            DomainEvents = new List<IEvent>();
        }

        [BsonIgnore]
        public List<IEvent> DomainEvents { get; private set; }

        protected void AddEvent(IEvent @event)
        {
            this.DomainEvents.Add(@event);
        }
    }
}
