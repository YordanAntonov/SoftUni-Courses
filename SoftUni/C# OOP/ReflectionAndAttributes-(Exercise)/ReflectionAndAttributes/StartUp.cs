namespace CommandPattern
{
    using Utilities;
    using Core;
    using Core.Interfaces;
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
