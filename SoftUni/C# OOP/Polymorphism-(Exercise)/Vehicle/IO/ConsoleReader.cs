using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.IO.Interfaces;

namespace Vehicle.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
       
    }
}
