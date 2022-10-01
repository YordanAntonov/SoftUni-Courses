using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input = Console.ReadLine();

            while (input != "No more tires")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                //FirtSet
                int firstTireYear = int.Parse(tokens[0]);
                double firstTirePressure = double.Parse(tokens[1]);
                //SecondSet
                int secondTireYear = int.Parse(tokens[2]);
                double secondTirePressure = double.Parse(tokens[3]);
                //ThirdSet
                int thirdTireYear = int.Parse(tokens[4]);
                double thirdTirePressure = double.Parse(tokens[5]);
                //FourthSet
                int fourthTireYear = int.Parse(tokens[6]);
                double fourthTirePressure = double.Parse(tokens[7]);

                Tire[] tireSet = new Tire[4]
                {
                    new Tire(firstTireYear, firstTirePressure),
                    new Tire(secondTireYear, secondTirePressure),
                    new Tire(thirdTireYear, thirdTirePressure),
                    new Tire(fourthTireYear, fourthTirePressure),
                };

                tires.Add(tireSet);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horePower, cubicCapacity);
                engines.Add(engine);

                command = Console.ReadLine();
            }

            string action = Console.ReadLine();

            while (action != "Show special")
            {
                string[] tokens = action.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tireIndex = int.Parse(tokens[6]);

                Car car = new Car(make, model ,year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);
                cars.Add(car);

                action = Console.ReadLine();
            }

            List<Car> specialCars = cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10).ToList();

            foreach (var specialCar in specialCars)
            {
                specialCar.Drive(20);
                Console.WriteLine(specialCar.WhoAmI());
            }

            




            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(1, 2.5),
            //    new Tire(1, 2.1),
            //    new Tire(2, 0.5),
            //    new Tire(2, 2.3),
            //};

            //Engine engine = new Engine(560, 6300);

            //Car car = new Car("Lamborgini", "Urus", 2010, 250, 9, engine, tires);

            //string make = Console.ReadLine();
            //string model = Console.ReadLine();
            //int year = int.Parse(Console.ReadLine());
            //double fuelQuantity = double.Parse(Console.ReadLine());
            //double fuelConsumption = double.Parse(Console.ReadLine());



            //Car firstCar = new Car();
            //Car secondCar = new Car(make, model, year);
            //Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            //Console.WriteLine(firstCar.WhoAmI());
            //Console.WriteLine();
            //Console.WriteLine(secondCar.WhoAmI());
            //Console.WriteLine();
            //Console.WriteLine(thirdCar.WhoAmI());


        }

    }
}
