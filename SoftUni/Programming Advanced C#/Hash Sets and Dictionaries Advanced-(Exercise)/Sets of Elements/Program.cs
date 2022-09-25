using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();
            int n = lengths[0];
            int m = lengths[1];

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setOne.Add(num);
            }
            for (int i = 0; i < m; i++)
            {
                int num = int.Parse(Console.ReadLine());
                setTwo.Add(num);
            }

            setOne.IntersectWith(setTwo);
            Console.WriteLine(String.Join(" ", setOne));
        }
    }
}
