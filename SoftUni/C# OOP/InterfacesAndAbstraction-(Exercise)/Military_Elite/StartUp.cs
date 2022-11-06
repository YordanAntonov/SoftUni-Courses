
namespace Military_Elite
{
    using Core;
    using Core.Interfaces;
    using IO;
    using IO.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter write = new ConsoleWriter();

            IEngine engine = new Engine(reader, write);
            engine.Run();
        }

    }
}
