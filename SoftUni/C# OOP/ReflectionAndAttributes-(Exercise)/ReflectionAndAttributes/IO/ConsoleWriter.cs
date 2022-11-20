namespace CommandPattern.IO
{
    using IO.Interfaces;
    using System;
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
