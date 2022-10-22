using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace ComputerArchitecture
{
    public class Computer
    {
        //*************CONSTRUCTOR*******************************
        public Computer(string model, int capacity)
        {
            Model = model;

            Capacity = capacity;

            Multiprocessor = new List<CPU>();
        }
        //*************PROPERTIES********************************
        public string Model { get; set; }

        public int Capacity { get; set; }

        public int MyProperty { get; set; }

        public List<CPU> Multiprocessor { get; set; }

        public int Count => Multiprocessor.Count;
        //*************CLASS METHODS*****************************

        public void Add(CPU cpu)
        {
            if (Multiprocessor.Count < Capacity)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand)
        {
            foreach (var processor in Multiprocessor)
            {
                if (processor.Brand == brand)
                {
                    Multiprocessor.Remove(processor);
                    return true;
                }
            }

            return false;
        }

        public CPU MostPowerful()
        {
            CPU mostPowerful = Multiprocessor.OrderByDescending(c => c.Frequency).First();
            return mostPowerful;
        }

        public CPU GetCPU(string brand)
        {
            CPU selectedCpu = Multiprocessor.FirstOrDefault(c => c.Brand == brand);
            return selectedCpu;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine($"{cpu}");
            }

            string result = sb.ToString().Trim();
            return result;
        }

    }
}
