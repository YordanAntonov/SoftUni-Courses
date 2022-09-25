using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periodic_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> periodicElements = new SortedSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] element = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                periodicElements.UnionWith(element);
            }

            Console.WriteLine(string.Join(" ", periodicElements));
        }
    }
}
