﻿namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> extensionFiles = new SortedDictionary<string, List<FileInfo>>();
            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!extensionFiles.ContainsKey(fileInfo.Extension))
                {
                    extensionFiles[fileInfo.Extension] = new List<FileInfo>();
                }
                extensionFiles[fileInfo.Extension].Add(fileInfo);
            }

            var orderedExtensions = extensionFiles.OrderByDescending(ef => ef.Value.Count);
            StringBuilder sb = new StringBuilder();

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;
            File.WriteAllText(filePath, textContent);
        }
    }
}
