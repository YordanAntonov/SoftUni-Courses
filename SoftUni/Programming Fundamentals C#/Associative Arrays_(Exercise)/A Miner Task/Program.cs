using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resources = "";
            Dictionary<string, int> mineralsAndQuantity = new Dictionary<string, int>();

            while ((resources = Console.ReadLine()) != "stop")
            {

                int quantity = int.Parse(Console.ReadLine());

                if (!mineralsAndQuantity.ContainsKey(resources))
                {
                    mineralsAndQuantity[resources] = quantity;
                }
                else
                {

                    mineralsAndQuantity[resources]+=quantity;
                }
            }

            foreach (var resource in mineralsAndQuantity)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }

        }
    }
}
