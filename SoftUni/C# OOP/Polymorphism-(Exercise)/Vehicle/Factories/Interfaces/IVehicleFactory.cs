using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Models.Interfaces;

namespace Vehicle.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
