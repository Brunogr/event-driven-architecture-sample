using Commander.Abstractions;
using MediatR;
using System;

namespace Commander
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, CommandResult> where TCommand : ICommand<CommandResult>
    {
    }
}
