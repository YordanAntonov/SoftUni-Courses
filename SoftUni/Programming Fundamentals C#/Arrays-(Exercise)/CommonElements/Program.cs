using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstArray = Console.ReadLine().Split().ToArray();
            string[] secondArray = Console.ReadLine().Split().ToArray();

            foreach(string word in firstArray)
            {
                for (int i = 0; i < secondArray.Length; i++)
                {
                    if(word == secondArray[i])
                    {
                        Console.Write($"{secondArray[i]} ");
                        break;
                    }
                }    

            }
        }
    }
}
