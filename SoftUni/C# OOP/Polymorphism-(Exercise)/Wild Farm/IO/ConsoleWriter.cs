using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.IO.Interface;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value.ToString());
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value.ToString());
        }
    }
}
