using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split().Where(word => word.Length % 2 == 0).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
            

        }
    }
}
