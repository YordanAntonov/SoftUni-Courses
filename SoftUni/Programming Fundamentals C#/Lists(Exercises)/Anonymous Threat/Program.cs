using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> inputString = Console.ReadLine().Split().ToList();
            string command = "";

            while ((command = Console.ReadLine()) != "3:1")
            {
                string[] tokens = command.Split();
                string margeOrDevide = tokens[0];
                string concatWord = "";
                int startIndex = int.Parse(tokens[1]);
                int endIndex = int.Parse(tokens[2]);

                if (endIndex > inputString.Count - 1 || endIndex < 0)
                {
                    endIndex = inputString.Count - 1;
                }

                if (startIndex < 0 || startIndex > inputString.Count - 1)
                {
                    startIndex = 0;
                }

                if (margeOrDevide == "merge")
                {

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatWord += inputString[i];
                    }
                    inputString.RemoveRange(startIndex, endIndex - startIndex + 1);
                    inputString.Insert(startIndex, concatWord);
                }
                else if (margeOrDevide == "divide")
                {
                    List<string> dividedInput = new List<string>();
                    int partitions = int.Parse(tokens[2]);
                    string word = inputString[startIndex];
                    int parts = word.Length / partitions;
                    inputString.RemoveAt(startIndex);

                    for (int i = 0; i < partitions; i++)
                    {
                        if (i == partitions - 1)
                        {
                            dividedInput.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            dividedInput.Add(word.Substring(i * parts, parts));
                        }
                    }

                    inputString.InsertRange(startIndex, dividedInput);
                }

            }
            Console.WriteLine(String.Join(" ", inputString));


        }

    }
}
