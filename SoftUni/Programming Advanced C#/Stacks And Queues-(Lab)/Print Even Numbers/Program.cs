using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> evens = new Queue<int>(numbers.Where(num => num % 2 == 0).ToList());

            
            //foreach (var num in numbers)
            //{
            //    if (num % 2 == 0)
            //    {
            //        evens.Enqueue(num);
            //    }
            //}
            Console.WriteLine(String.Join(", ", evens));
        }
    }
}
