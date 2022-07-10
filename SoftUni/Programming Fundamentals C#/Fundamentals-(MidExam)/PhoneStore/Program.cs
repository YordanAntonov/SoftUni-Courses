using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phones = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = "";

            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();

                if (tokens[0] == "Add")
                {
                    AddPhone(tokens[2], phones);
                }
                else if (tokens[0] == "Remove")
                {
                    RemovePhone(tokens[2], phones);
                }
                else if (tokens[0] == "Bonus")
                {
                    string[] models = tokens[3].Split(':');
                    AddBonusPhones(models[0], models[1], phones);
                }
                else if (tokens[0] == "Last")
                {
                    PutAtLast(tokens[2], phones);
                }
            }
            Console.WriteLine(string.Join(", ", phones));
        }

        static void PutAtLast(string phone, List<string> phones)
        {
            if (phones.Contains(phone))
            {
                phones.Add(phone);
                phones.Remove(phone);

            }
            else
            {

                return;
            }
        }

        private static void AddBonusPhones(string oldModel, string newModel, List<string> phones)
        {
            if (phones.Contains(oldModel))
            {
                for (int i = 0; i < phones.Count; i++)
                {
                    if (oldModel == phones[i])
                    {
                        phones.Insert(i + 1, newModel);
                    }
                }

            }
            else
            {

                return;
            }
        }

        static void RemovePhone(string phone, List<string> phones)
        {
            if (!phones.Contains(phone))
            {

                return;
            }
            else
            {
                phones.Remove(phone);
            }
        }

        static void AddPhone(string phone, List<string> phones)
        {
            if (phones.Contains(phone))
            {

                return;
            }
            else
            {
                phones.Add(phone);
            }
        }
    }
}
