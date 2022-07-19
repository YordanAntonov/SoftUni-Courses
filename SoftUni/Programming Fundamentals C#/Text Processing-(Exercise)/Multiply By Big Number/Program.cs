using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multiply_By_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            // 9999
            //    9
            // = 89991   
            int leftOver = 0;
            StringBuilder sb = new StringBuilder();

            if (multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                char curentChar = bigNumber[i];
                int currNumber = int.Parse(curentChar.ToString());

                int sum = 0;
                sum += leftOver;
                sum += currNumber * multiplier;
                leftOver = sum / 10;
                sb.Append(sum % 10);

            }
            if (leftOver != 0)
            {
                sb.Append(leftOver);
            }

            StringBuilder reversed = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                reversed.Append(sb[i]);
            }
            Console.WriteLine(reversed);

        }
    }
}
