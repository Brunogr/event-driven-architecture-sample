using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Abstractions
{
    public interface ICommand<TCommandResult> : IRequest<TCommandResult>, IMessage where TCommandResult : ICommandResult
    {
        bool Valid { get; }
        bool Invalid { get; }
        bool Validate();
    }
}
