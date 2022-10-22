using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerArchitecture
{
    public class CPU
    {
        //*************CONSTRUCTOR*******************************
        public CPU(string brand, int cores, double frequency)
        {
            Brand = brand;

            Cores = cores;

            Frequency = frequency;
        }
        //*************PROPERTIES********************************
        public string Brand { get; set; }

        public int Cores { get; set; }

        public double Frequency  { get; set; }

        //*************CLASS METHODS*****************************

        public override string ToString()
        {
            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{Brand} CPU:");
            sb.AppendLine($"Cores: {Cores}");
            sb.AppendLine($"Frequency: {Frequency:f1} GHz");
            string result = sb.ToString().Trim();
            return result;
        }

        // AMD Ryzen 5 CPU:
        // Cores: 6
        // Frequency: 3.7 GHz
    }
}
