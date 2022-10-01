using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Action_Point
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> namePrinter = n => Console.WriteLine(String.Join(Environment.NewLine, n));
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            namePrinter(names);

        }
    }
}
