using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalQuantity = int.Parse(Console.ReadLine());
            Queue<int> ordersQuantity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            int biggestOrder = ordersQuantity.Max();
            int numOfOrders = ordersQuantity.Count;

            for (int i = 0; i < numOfOrders; i++)
            {
                int currOrder = ordersQuantity.Peek();
                if (currOrder <= totalQuantity)
                {
                    totalQuantity -= ordersQuantity.Dequeue();
                }
            }

            Console.WriteLine(biggestOrder);
            if (ordersQuantity.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersQuantity)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
