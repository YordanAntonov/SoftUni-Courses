using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_of_Products_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int entries = int.Parse(Console.ReadLine());
            List<string> fruits = new List<string>();

            for (int i = 0; i < entries; i++)
            {
                fruits.Add(Console.ReadLine());
            }
            fruits.Sort();
            for (int i = 0; i < fruits.Count; i++)
            {

                Console.WriteLine($"{i + 1}.{fruits[i]}");
            }


        }
    }
}
