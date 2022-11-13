using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.IO.Interfaces
{
    public interface IWriter
    {
        void Write(string value);

        void WriteLine(string value);
    }
}
