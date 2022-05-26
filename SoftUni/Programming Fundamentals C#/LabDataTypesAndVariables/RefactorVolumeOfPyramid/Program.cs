using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorVolumeOfPyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Length: ");
            double length = double.Parse(Console.ReadLine());


            Console.Write("Width: ");
            double width = double.Parse(Console.ReadLine());


            Console.Write("Height: ");
            double heigth = double.Parse(Console.ReadLine());


            double volume = (length * width * heigth) / 3;
            Console.Write($"Pyramid Volume: {volume:f2}");
        }
    }
}
