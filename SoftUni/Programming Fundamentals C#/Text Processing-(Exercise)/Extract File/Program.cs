using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] fileDirectory = Console.ReadLine().Split(new[] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
            string fileName = "";
            string fileExtension = "";

            for (int i = 0; i < fileDirectory.Length; i++)
            {
                string currentCheck = fileDirectory[i];
                if (currentCheck.Contains('.'))
                {
                    string[] fileNameAndExtension = currentCheck.Split('.');
                    fileName = fileNameAndExtension[0];
                    fileExtension = fileNameAndExtension[1];
                }
            }
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");

        }
    }
}
