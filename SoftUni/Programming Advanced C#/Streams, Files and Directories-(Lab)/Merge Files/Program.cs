using System;
using System.IO;
using System.Linq;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath,
           outputFilePath);
        }

        private static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using StreamReader firstReader = new StreamReader(firstInputFilePath);
            {
                using StreamReader secondLines = new StreamReader(secondInputFilePath);
                {
                    using StreamWriter writer = new StreamWriter(outputFilePath);
                    {
                        string[] readLines = firstReader.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                        string[] secondLines = secondLines.ReadToEnd().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
                        CheckArraysSizes(readLines, secondLines);

                        int biggerLenght = 0;
                        int smallerLenght = 0;
                        if (readLines.Length > secondLines.Length)
                        {
                            biggerLenght = readLines.Length;
                            smallerLenght = secondLines.Length;
                        }
                        else
                        {
                            biggerLenght = secondLines.Length;
                            smallerLenght = readLines.Length;
                        }

                        for (int i = 0; i < biggerLenght; i++)
                        {
                            writer.WriteLine(readLines[i]);
                            writer.WriteLine(secondLines[i]);
                        }
                        
                        
                    }
                }
            }
        }

        
    }

}

