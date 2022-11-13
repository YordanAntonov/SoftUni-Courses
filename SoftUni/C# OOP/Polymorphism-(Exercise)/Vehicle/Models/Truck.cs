using System;
using System.Collections.Generic;
using System.Text;
using Vehicle.Exceptions;

namespace Vehicle.Models
{
    public class Truck : Vehicle
    {
        private const double airConditionerConsumption = 1.6;
        private const double leakingFuelPercentage = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, airConditionerConsumption, tankCapacity)
        {

        }

        public override void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new FuelCannotBeNegativeException();
            }

            double refuelingChecker = this.FuelQuantity + liters;

            if (refuelingChecker > this.TankCapacity)
            {
                throw new TankOverflowException(string.Format(ExceptionMessages.TankOverFlowException, liters));
            }

            double refueldFuel = liters * leakingFuelPercentage;
            base.Refuel(refueldFuel);
        }
    }
}
