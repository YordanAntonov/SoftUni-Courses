using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;

            Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine, weight)
        {
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }

        // Optional
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            string weight = Weight == 0 ? "n/a" : Weight.ToString();
            string color = Color == null ? "n/a": Color.ToString();
            string result =
                $"{Model}:{Environment.NewLine}" +
                $"{Engine.ToString()}{Environment.NewLine}" +
                $"Weight: {weight}{Environment.NewLine}" +
                $"Color: {color}";

            return result;
        }
    }
}
