namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            string[] files = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < files.Length; i++)
            {
                int lettersCount = files[i].Count(ch => char.IsLetter(ch));
                int symbolsCount = files[i].Count(ch => char.IsPunctuation(ch));

                sb.AppendLine($"Line {i + 1}: {files[i]} ({lettersCount})({symbolsCount})");
            }

            File.WriteAllText(outputFilePath, sb.ToString());
        }
    }
}
