using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Need_For_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < iterations; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string carBrand = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);

                Car car = new Car (carBrand, mileage, fuel);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command.Split(new[] {" : "}, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string carBrand = tokens[1];

                switch (action)
                {
                    case "Drive":
                        {
                            int distance = int.Parse(tokens[2]);
                            int fuel = int.Parse(tokens[3]);
                            Drive(carBrand, distance, fuel, cars);
                        }
                        break;

                    case "Refuel":
                        {
                            int fuel = int.Parse(tokens[2]);
                            Refuel(carBrand, fuel, cars);
                        }
                        break;
                    case "Revert":
                        {
                            int kilometers = int.Parse(tokens[2]);
                            Revert(carBrand, kilometers, cars);
                        }

                        break;
                }

                command = Console.ReadLine();
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Brand} -> Mileage: {car.Mileage} kms, Fuel in the tank: {car.Fuel} lt.");
            }
        }

        static void Revert(string carBrand, int kilometers, List<Car> cars)
        {
            Car currCar = cars.First(c => c.Brand == carBrand);
            currCar.Mileage -= kilometers;
            if (currCar.Mileage < 10000)
            {
                currCar.Mileage = 10000;
                return;
            }
            Console.WriteLine($"{currCar.Brand} mileage decreased by {kilometers} kilometers");
        }

        static void Refuel(string carBrand, int fuel, List<Car> cars)
        {
            Car currCar = cars.First(c => c.Brand == carBrand);
            int refulledFuel = currCar.Fuel + fuel;
            if (refulledFuel > 75)
            {
                refulledFuel = 75;
            }
            int fuelNeeded = refulledFuel - currCar.Fuel;
            currCar.Fuel += fuelNeeded;
            Console.WriteLine($"{currCar.Brand} refueled with {fuelNeeded} liters");
        }

        static void Drive(string carBrand, int distance, int fuel, List<Car> cars)
        {
            Car currCar = cars.First(c => c.Brand == carBrand);
            if (currCar.Fuel < fuel)
            {
                Console.WriteLine("Not enough fuel to make that ride");
                return;
            }
            else
            {
                currCar.Fuel -= fuel;
                currCar.Mileage += distance;
                Console.WriteLine($"{currCar.Brand} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                if (currCar.Mileage >= 100_000)
                {
                    Console.WriteLine($"Time to sell the {currCar.Brand}!");
                    cars.Remove(currCar);
                }
            }
        }
    }
    class Car
    {
        public Car(string brand, int mileage, int fuel)
        {
            Brand = brand;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Brand  { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
