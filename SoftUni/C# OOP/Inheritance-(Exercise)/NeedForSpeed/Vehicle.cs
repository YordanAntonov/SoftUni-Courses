using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        private int horsePower;
        private double fuel;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }


        public double Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public virtual double FuelConsumption => DEFAULT_FUEL_CONSUMPTION;

        public virtual void Drive(double kilometers)
        {
            double leftFuelAfterRide = Fuel - FuelConsumption * kilometers; 

            if (leftFuelAfterRide >= 0)  Fuel -= FuelConsumption * kilometers;

        }
    }
}
