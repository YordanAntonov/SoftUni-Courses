
namespace OddLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ExtractOddLines(inputFilePath, outputFilePath);
        }
        public static void ExtractOddLines(string inputFilePath, string
       outputFilePath)
        {
            using (StreamReader reader = new StreamReader(inputFilePath))
            {

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {

                    int oddLines = 0;
                    int line = 0;


                    while (!reader.EndOfStream)
                    {
                        string lines = reader.ReadLine();
                        if (line % 2 == 1)
                        {
                            writer.WriteLine(lines);
                        }
                        oddLines++;
                    }

                }

            }
        }
    }
}

