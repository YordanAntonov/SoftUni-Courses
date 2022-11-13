
namespace Vehicle
{
    using Vehicle.Core;
    using Vehicle.Core.Interfaces;
    using Vehicle.Factories;
    using Vehicle.Factories.Interfaces;
    using Vehicle.IO;
    using Vehicle.IO.Interfaces;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }
    }
}
