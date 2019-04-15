using Commander.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Core
{
    public abstract class Event : IEvent
    {
        protected Event()
        {
            Timestamp = DateTimeOffset.Now;
            MessageType = GetType().Name;
        }

        public DateTimeOffset Timestamp { get; private set; }

        public string MessageType { get; private set; }
    }
}
