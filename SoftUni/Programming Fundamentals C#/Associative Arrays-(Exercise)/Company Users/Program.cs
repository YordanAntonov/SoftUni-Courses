using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Users
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Dictionary<string, List<string>> companyRecord = new Dictionary<string, List<string>>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] companyInfo = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string companyName = companyInfo[0];
                string companyId = companyInfo[1];
                if (!companyRecord.ContainsKey(companyName))
                {
                    companyRecord[companyName] = new List<string>();
                }
                if (!companyRecord[companyName].Contains(companyId))
                {
                    companyRecord[companyName].Add(companyId);
                }

            }

            foreach (var company in companyRecord)
            {
                Console.WriteLine(company.Key);
                foreach (var person in company.Value)
                {
                    Console.WriteLine($"-- {person}");
                }
            }
        }
    }
}
