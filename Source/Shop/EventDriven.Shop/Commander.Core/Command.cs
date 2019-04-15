using Commander.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Core
{
    public abstract class Command : ICommand<CommandResult>
    {
        public Command()
        {
            MessageType = GetType().Name;
            Timestamp = DateTimeOffset.Now;
        }
        public bool Valid => Validate();

        public bool Invalid => !Validate();

        public string MessageType { get; }

        public DateTimeOffset Timestamp { get; }

        public abstract bool Validate();
    }
}
