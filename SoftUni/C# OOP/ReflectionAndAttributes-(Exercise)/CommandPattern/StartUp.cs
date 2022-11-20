using CommandPattern.Core.Contracts;
using CommandPattern.Utilities;
using System;

namespace CommandPattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CommandInterpreter commandInterpreter = new CommandInterpreter();

            IEngine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}
