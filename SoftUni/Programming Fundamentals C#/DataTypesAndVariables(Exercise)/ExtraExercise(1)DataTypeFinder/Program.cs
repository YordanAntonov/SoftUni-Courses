using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtraExercise_1_DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            int valueInt = 0;
            float valueFloat = 0;
            char valueChar;
            bool valueBool;
            string valueString;


            while (dataType != "END")
            {
                if (int.TryParse(dataType, out valueInt))
                {
                    Console.WriteLine($"{dataType} is integer type");
                }
                else if (float.TryParse(dataType, out valueFloat))
                {
                    Console.WriteLine($"{dataType} is floating point type");
                }
                else if (char.TryParse(dataType, out valueChar))
                {
                    Console.WriteLine($"{dataType} is character type");
                }
                else if (bool.TryParse(dataType, out valueBool))
                {
                    Console.WriteLine($"{dataType} is boolean type");
                }
                else
                {
                    Console.WriteLine($"{dataType} is string type");
                }
                dataType = Console.ReadLine();
            }
        }
    }
}
