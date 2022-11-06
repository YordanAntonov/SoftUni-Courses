using Military_Elite.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string text)
        {
           Console.Write(text);
        }

        public void WriteLine(string text)
        {

            Console.WriteLine(text);
        }
    }
}
