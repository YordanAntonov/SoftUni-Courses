using Military_Elite.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine() => Console.ReadLine();
        
    }
}
