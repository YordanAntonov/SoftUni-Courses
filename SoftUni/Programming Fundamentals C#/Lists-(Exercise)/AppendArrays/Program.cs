using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbersList = Console.ReadLine().Split('|').Reverse().ToList();

            List<int> secondNumList = new List<int>();
            foreach (string number in numbersList)
            {
                secondNumList.AddRange(number.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());   
            }
            Console.WriteLine(string.Join(" ", secondNumList));
        }
    }
}
