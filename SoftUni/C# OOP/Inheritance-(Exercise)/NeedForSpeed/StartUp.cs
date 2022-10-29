using System;

namespace NeedForSpeed
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            RaceMotorcycle vehicle = new RaceMotorcycle(200, 200);
            vehicle.Drive(10);
            Console.WriteLine(vehicle.Fuel);

        }
    }
}
