
namespace Raiding.IO
{
    using Raiding.IO.Interfaces;
    using System;
    public class ConsoleWriter : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
