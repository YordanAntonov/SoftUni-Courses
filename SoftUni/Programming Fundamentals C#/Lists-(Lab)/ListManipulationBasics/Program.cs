using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                int movingComand = int.Parse(commands[1]);
                if (commands[0] == "Add")
                {
                    numbers.Add(movingComand);
                }
                else if (commands[0] == "Remove")
                {
                    numbers.Remove(movingComand);
                }
                else if (commands[0] == "RemoveAt")
                {
                    numbers.RemoveAt(movingComand);
                }
                else if (commands[0] == "Insert")
                {
                    int supportCommand = int.Parse(commands[2]);
                    numbers.Insert(supportCommand, movingComand);
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
