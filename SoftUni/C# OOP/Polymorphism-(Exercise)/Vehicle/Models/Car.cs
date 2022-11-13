using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Models
{
    public class Car : Vehicle
    {
        private const double airConditionerConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, airConditionerConsumption, tankCapacity)
        {

        }
    }
}
