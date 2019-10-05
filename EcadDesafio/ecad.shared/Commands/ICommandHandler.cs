using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.shared.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
        ICommandResult Handler(T command);
    }
}
