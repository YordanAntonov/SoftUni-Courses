using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Exceptions;

namespace Vehicle.Models
{
    public class Bus : Vehicle
    {
        private const double AirConditionerConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, AirConditionerConsumption, tankCapacity)
        {

        }

        public string DriveEmptyBus(double distance)
        {
            double normalFuelConsumption = this.FuelConsumption - AirConditionerConsumption;

            double fuelNeeded = distance * normalFuelConsumption;
            if (fuelNeeded > base.FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelException, this.GetType().Name));
            }

            base.TakeOutGas(fuelNeeded);

            return $"{this.GetType().Name} travelled {distance} km";
        }
    }
}
