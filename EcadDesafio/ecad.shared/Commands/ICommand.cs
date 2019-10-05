using System;
using System.Collections.Generic;
using System.Text;

namespace ecad.shared.Commands
{
    public interface ICommand
    {
        bool Valid();
    }
}
