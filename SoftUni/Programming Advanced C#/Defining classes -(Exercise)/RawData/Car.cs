using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(string model, int speed, int power, int weight, string type, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine  = new Engine()
            {
               Power = power,
               Speed = speed,
            };
            Cargo  = new Cargo
            {
                Weight = weight,
                Type = type,
            };

            Tyres = new Tires[4];

            Tyres[0] = new Tires
            {
                Pressure = tire1Pressure,
                Age = tire1Age
            };  Tyres[1] = new Tires
            {
                Pressure = tire2Pressure,
                Age = tire2Age
            };  Tyres[2] = new Tires
            {
                Pressure = tire3Pressure,
                Age = tire3Age
            };  Tyres[3] = new Tires
            {
                Pressure = tire4Pressure,
                Age = tire4Age
            };
            
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tyres { get; set; }
               
    }
}
