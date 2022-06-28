using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string commands = Console.ReadLine();

            while (commands != "end")
            {
                string[] tokens = commands.Split();
                int element = int.Parse(tokens[1]);

                if (tokens[0] == "Delete")
                {
                    numbers.RemoveAll(x => element == x);
                }
                else if (tokens[0] == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    numbers.Insert(index, element);
                }

                commands = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
