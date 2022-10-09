using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Engine engine = ConstructEngine(tokens);
                engines.Add(engine);
            }

            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = ConstructACar(tokens, engines);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }

        }

        private static Engine ConstructEngine(string[] tokens)
        {
            string model = tokens[0];
            int power = int.Parse(tokens[1]);
            if (tokens.Length > 2)//Optional
            {
                if (tokens.Length == 3)
                {
                    string displacementOfEfficiency = tokens[2];
                    if (char.IsDigit(displacementOfEfficiency[0]))
                    {
                        int displacement = int.Parse(tokens[2]);
                        Engine engine = new Engine(model, power, displacement);

                        return engine;
                    }
                    else
                    {
                        string efficiency = tokens[2];
                        Engine engine = new Engine(model, power, efficiency);

                        return engine;
                    }

                }
                else if (tokens.Length == 4)
                {
                    Engine engine = new Engine(model, power, int.Parse(tokens[2]), tokens[3]);
                    return engine;
                }
            }
            else
            {
                Engine engine = new Engine(model, power);
                return engine;
            }

            return null;
        }

        private static Car ConstructACar(string[] tokens, List<Engine> engines)
        {
            string model = tokens[0];
            string engineModel = tokens[1];
            Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);

            if (tokens.Length > 2)//Optional
            {
                if (tokens.Length == 3)
                {
                    string colorOrWeight = tokens[2];
                    if (char.IsDigit(colorOrWeight[0]))
                    {
                        int weight = int.Parse(tokens[2]);
                        Car car = new Car(model, engine, weight);

                        return car;
                    }
                    else
                    {
                        string color = tokens[2];
                        Car car = new Car(model, engine, color);
                        return car;
                    }

                }
                else if (tokens.Length == 4)
                {
                    Car car = new Car(model, engine, int.Parse(tokens[2]), tokens[3]);
                    return car;
                }
            }
            else
            {
                Car car = new Car(model, engine);
                return car;
            }

            return null;
        }
    }
}
