
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Commander.Abstractions
{
    public interface IHandler
    {
        Task<CommandResult> Send<TCommand>(TCommand command, CancellationToken cancellationToken = default(CancellationToken))
            where TCommand : ICommand<CommandResult>;
        
        Task Validate<T>(T entity) where T : IValidatable;

        Task RaiseEvent<TEvent>(TEvent @event, CancellationToken cancellationToken = default(CancellationToken))
            where TEvent : IEvent;
    }
}
