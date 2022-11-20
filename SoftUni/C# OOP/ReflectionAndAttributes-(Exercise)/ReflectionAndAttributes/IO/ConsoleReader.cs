namespace CommandPattern.IO
{
    using IO.Interfaces;
    using System;
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();

    }
}
