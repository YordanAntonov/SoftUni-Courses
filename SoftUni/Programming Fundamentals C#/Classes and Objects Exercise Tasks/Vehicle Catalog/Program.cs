using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Catalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string specifications = "";
            List<Vehicle> vehicles = new List<Vehicle>();


            while ((specifications = Console.ReadLine()) != "End")
            {
                string[] _specifications = specifications.Split();
                string type = _specifications[0];
                string model = _specifications[1];
                string color = _specifications[2];
                int horsePower = int.Parse(_specifications[3]);

                switch (type)
                {
                    case "car":
                        Vehicle car = new Vehicle(type, model, color, horsePower);
                        vehicles.Add(car);
                        break;
                    case "truck":
                        Vehicle truck = new Vehicle(type, model, color, horsePower);
                        vehicles.Add(truck);
                        break;
                }
            }

            string searchedVehicle = "";

            while ((searchedVehicle = Console.ReadLine()) != "Close the Catalogue")
            {
                if (vehicles.Any(vehicle => vehicle.Model == searchedVehicle))
                {
                    Vehicle desiredVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == searchedVehicle);
                    Console.WriteLine(desiredVehicle);
                }
            }

            List<Vehicle> carsCatalogue = vehicles.Where(vehicle => vehicle.Type == "car").ToList();
            List<Vehicle> truckCatalogue = vehicles.Where(vehicle => vehicle.Type == "truck").ToList();

            double carsAverageHp = carsCatalogue.Count > 0 ? carsCatalogue.Average(car => car.HorsePower) : 0.00; 
            double truckAverageHp = truckCatalogue.Count > 0 ? truckCatalogue.Average(truck => truck.HorsePower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHp:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {truckAverageHp:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Type: {char.ToUpper(Type[0]) + Type.Substring(1).ToLower()}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");
            return sb.ToString().TrimEnd();
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

    }
}
