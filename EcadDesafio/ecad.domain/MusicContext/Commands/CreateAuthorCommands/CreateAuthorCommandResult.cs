using ecad.shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.domain.MusicContext.Commands.CreateAuthorCommands
{
    public class CreateAuthorCommandResult: ICommandResult
    {
        public CreateAuthorCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
