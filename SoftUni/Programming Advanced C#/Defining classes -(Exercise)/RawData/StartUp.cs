using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> carCatalog = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = tokens[0];
                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);
                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];
                double tireOnePressure = double.Parse(tokens[5]);
                int tireOneAge = int.Parse(tokens[6]);
                double tireTwoPressure = double.Parse(tokens[7]);
                int tireTwoAge = int.Parse(tokens[8]);
                double tireThreePressure = double.Parse(tokens[9]);
                int tireThreeAge = int.Parse(tokens[10]);
                double tireFourPressure = double.Parse(tokens[11]);
                int tireFourAge = int.Parse(tokens[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tireOnePressure, tireOneAge, tireTwoPressure, tireTwoAge, tireThreePressure, tireThreeAge, tireFourPressure, tireFourAge);
                carCatalog.Add(car);

            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                List<Car> selectedCars = carCatalog.Where(c => c.Cargo.Type == "fragile" && c.Tyres.Any(t => t.Pressure < 1)).ToList();
                CarsPrinter(selectedCars);
            }
            else if (command == "flammable")
            {
                List<Car> selectedCars = carCatalog.Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250).ToList();
                CarsPrinter(selectedCars);
            }
        }

        private static void CarsPrinter(List<Car> selectedCars)
        {
            foreach (var car in selectedCars)
            {
                Console.WriteLine($"{car.Model}");
            }
        }
    }
}
