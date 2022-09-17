using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            StringBuilder text = new StringBuilder();
            //Stack for undo option
            Stack<string> undoSaves = new Stack<string>();
            undoSaves.Push(string.Empty);

            for (int i = 0; i < iterations; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string action = tokens[0];

                switch (action)
                {
                    case "1":
                        string stringToAdd = tokens[1];
                        text.Append(stringToAdd);
                        undoSaves.Push(text.ToString());
                        break;

                    case "2":
                        int count = int.Parse(tokens[1]);
                        int startIndex = text.Length - count;
                        text.Remove(startIndex, count);
                        undoSaves.Push(text.ToString());
                        break;

                    case "3":
                        int index = int.Parse(tokens[1]);
                        if (index >= 0 && index <= text.Length)
                        {
                            Console.WriteLine(text[index - 1]);
                        }
                        break;

                    case "4":
                        if (undoSaves.Any())
                        {
                            undoSaves.Pop();//Removes current Version
                            text = new StringBuilder(undoSaves.Peek());
                        }
                        break;
                }
            }
        }
    }
}
