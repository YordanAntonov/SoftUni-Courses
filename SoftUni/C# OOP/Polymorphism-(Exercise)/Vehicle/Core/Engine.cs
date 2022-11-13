
namespace Vehicle.Core
{
    using Interfaces;
    using Vehicle.IO;
    using IO.Interfaces;
    using Vehicle.Models.Interfaces;
    using Vehicle.Factories.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Vehicle.Exceptions;
    using Vehicle.Models;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IVehicleFactory vehicleFactory;

        private readonly ICollection<IVehicle> vehicles;

        public Engine()
        {
            this.vehicles = new HashSet<IVehicle>();
        }
        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;
        }

        public void Run()
        {
            this.vehicles.Add(this.BuildVehicleUsingFactory());
            this.vehicles.Add(this.BuildVehicleUsingFactory());
            this.vehicles.Add(this.BuildVehicleUsingFactory());

            int num = int.Parse(reader.ReadLine());

            for (int i = 0; i < num; i++)
            {
                try
                {
                    this.ProcessCommand();
                }
                catch (InsufficientFuelException ifs)
                {
                    writer.WriteLine(ifs.Message);
                }
                catch (InvalidVehicleException iv)
                {
                    writer.WriteLine(iv.Message);
                }
                catch (FuelCannotBeNegativeException fcbn)
                {
                    writer.WriteLine(fcbn.Message);
                }
                catch(TankOverflowException toe)
                {
                    writer.WriteLine(toe.Message);
                }
            }

            this.PrintVehicles();
        }

        private IVehicle BuildVehicleUsingFactory()
        {
            string[] vehicleArgs = this.reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = vehicleArgs[0];
            double vehicleFuelQuantity = double.Parse(vehicleArgs[1]);
            double vehicleFuelConsumption = double.Parse(vehicleArgs[2]);
            double tankCapacity = double.Parse(vehicleArgs[3]);

            IVehicle vehicle = this.vehicleFactory.CreateVehicle(vehicleType, vehicleFuelQuantity, vehicleFuelConsumption, tankCapacity);

            return vehicle;
        }

        private void ProcessCommand()
        {
            string[] cmdArgs = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);
            string action = cmdArgs[0];
            string vehicleType = cmdArgs[1];
            double distanceOrLiters = double.Parse(cmdArgs[2]);

            IVehicle currVehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (currVehicle == null)
            {
                throw new InvalidVehicleException();
            }

            switch (action)
            {
                case "Drive":
                    writer.WriteLine(currVehicle.Drive(distanceOrLiters));
                    break;

                case "Refuel":
                    currVehicle.Refuel(distanceOrLiters);
                    break;
                case "DriveEmpty":
                    Bus currBus = (Bus)currVehicle;
                    writer.WriteLine(currBus.DriveEmptyBus(distanceOrLiters));
                    break;
            }
        }

        private void PrintVehicles()
        {
            foreach (IVehicle vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

    }
}
