using System;
using System.IO;
using System.Linq;
using System.Text;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";
            RewriteFileWithLineNumbers(inputPath, outputPath);
        }
        public static void RewriteFileWithLineNumbers(string inputFilePath, string
       outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            {
                using StreamWriter writer = new StreamWriter(outputFilePath);
                {
                    int lineCount = 1;
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        writer.WriteLine($"{lineCount}.  {line}");
                        lineCount++;
                    }
                }
            }
        }
    }
}

