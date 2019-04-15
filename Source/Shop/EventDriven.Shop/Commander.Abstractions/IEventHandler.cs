using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Abstractions
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent> where TEvent : IEvent
    {
    }
}
