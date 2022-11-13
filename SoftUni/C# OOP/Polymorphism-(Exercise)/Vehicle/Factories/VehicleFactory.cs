using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Exceptions;
using Vehicle.Factories.Interfaces;
using Vehicle.Models;
using Vehicle.Models.Interfaces;

namespace Vehicle.Factories
{
    public class VehicleFactory : IVehicleFactory
    {

        public IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            IVehicle vehicle;
            if (type == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
            }
            else
            {
                throw new InvalidVehicleException();
            }

            return vehicle;
        }
    }
}
