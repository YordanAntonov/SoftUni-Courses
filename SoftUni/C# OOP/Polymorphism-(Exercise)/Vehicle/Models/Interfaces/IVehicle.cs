using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Models.Interfaces
{
    public interface IVehicle
    {
        public double FuelQuantity { get; }
        public double FuelConsumption { get; }

        public double TankCapacity { get; }

        string Drive(double distance);

        void Refuel(double liters);
    }
}
