using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.MessageBus.Abstractions
{
    public interface IMessageBusConfiguration
    {
        string ConnectionString { get; }

    }
}
