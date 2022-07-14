using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string substringToRemove = Console.ReadLine();
            string sentance = Console.ReadLine();

            while (sentance.Contains(substringToRemove))
            {
                int startIndexOfSubstring = sentance.IndexOf(substringToRemove);
                sentance = sentance.Remove(startIndexOfSubstring, substringToRemove.Length);
            }
            Console.WriteLine(sentance);

            //while (sentance.Contains(substringToRemove))
            //{
            //    sentance = sentance.Replace(substringToRemove, string.Empty);
            //}
        }
    }
}
