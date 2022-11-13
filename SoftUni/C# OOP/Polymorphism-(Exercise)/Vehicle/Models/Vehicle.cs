
namespace Vehicle.Models
{
    using System;
    using Exceptions;
    using Models.Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double airConditionerConsump, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption + airConditionerConsump;
            TankCapacity = tankCapacity;
        }

        public virtual double FuelQuantity { get; private set; }

        public double FuelConsumption { get; private set; }

        public double TankCapacity
        {
            get { return tankCapacity; }

            private set
            {
                if (value < FuelQuantity)
                {
                    FuelQuantity = 0;
                }
                
                tankCapacity= value;
            }
        }


        public string Drive(double distance)
        {
           
            double fuelNeeded = distance * FuelConsumption;
            if (fuelNeeded > this.FuelQuantity)
            {
                throw new InsufficientFuelException(string.Format(ExceptionMessages.InsufficientFuelException, this.GetType().Name));
            }

            this.FuelQuantity -= fuelNeeded;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new FuelCannotBeNegativeException();
            }

            double refuelingChecker = this.FuelQuantity + liters;

            if (refuelingChecker > TankCapacity)
            {
                throw new TankOverflowException(string.Format(ExceptionMessages.TankOverFlowException, liters));
            }

            this.FuelQuantity += liters;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }

        protected void TakeOutGas(double liters)
        {
            this.FuelQuantity -= liters;
        }
    }
}
