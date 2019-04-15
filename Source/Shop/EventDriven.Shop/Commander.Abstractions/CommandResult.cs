using System;
using System.Collections.Generic;
using System.Text;

namespace Commander.Abstractions
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            Success = false;
        }

        public CommandResult(bool success)
        {
            Success = success;
        }

        public CommandResult(bool success, object data) : this(success)
        {
            Data = data;
        }

        public CommandResult(bool success, object data, string message) : this(success, data)
        {
            Message = message;
        }

        public bool Success { get; private set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
