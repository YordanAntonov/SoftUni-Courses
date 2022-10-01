    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace Find_Even_or_Odds
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<int> allNumbers = new List<int>();
            

                int[] ranges = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int lowerRange = ranges[0];
                int higherRange = ranges[1];
                string command = Console.ReadLine();

                for (int i = lowerRange; i <= higherRange; i++)
                {
                    allNumbers.Add(i);
                }

                List<int> selectedNumbers = allNumbers.FindAll(isEvenOrOdd(command));
                Console.WriteLine(string.Join(" ", selectedNumbers));


            }

            public static Predicate<int> isEvenOrOdd(string command)
            {
                if (command == "even")
                {
                    return x => x % 2 == 0;
                }
                else
                {
                    return x => x % 2 != 0;
                }
            }
        }
    }
