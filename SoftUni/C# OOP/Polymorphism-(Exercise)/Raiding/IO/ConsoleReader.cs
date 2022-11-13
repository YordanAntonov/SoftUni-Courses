
namespace Raiding.IO
{
    using Raiding.IO.Interfaces;
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
