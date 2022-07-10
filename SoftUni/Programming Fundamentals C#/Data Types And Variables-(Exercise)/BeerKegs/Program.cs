using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerKegs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //input
            int numberOfKegs = int.Parse(Console.ReadLine());
            double biggestKeg = double.MinValue;
            string nameBuggestKeg = "";

            for (int i = 0; i < numberOfKegs; i++)
            {
                string nameOfKeg = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());
                // π * r^2 * h
                double volume = Math.PI * (Math.Pow(radius, 2) * height);
                if(volume > biggestKeg)
                {
                    biggestKeg = volume;
                    nameBuggestKeg = nameOfKeg;
                }
            }
            Console.WriteLine(nameBuggestKeg);
        }
    }
}
