namespace CommandPattern
{
    using CommandPattern.IO.Interfaces;
    using System.Diagnostics.Contracts;
    using IO;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader  reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();

        }

        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.commandInterpreter = commandInterpreter;
        }

        public IWriter Writer => writer;

        public void Run()
        {
            try
            {
                while (true)
                {
                    string[] inputArgd = reader.ReadLine().Split(" ").ToArray();
                    string cmdName = inputArgd[0];
                    string[] args = inputArgd.Skip(1).ToArray();

                    string result = this.commandInterpreter.Read(cmdName, args);
                    this.Writer.WriteLine(result);
                }
            }
            catch(InvalidOperationException ioe)
            {
                Writer.WriteLine(ioe.Message);
            }
        }
    }
}
