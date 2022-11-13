
namespace Raiding
{
    using Core;
    using Core.Interfaces;
    using Factories;
    using Factories.Interfaces;
    using IO;
    using IO.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IHeroFactory heroFactory = new HeroFactory();

            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}
