using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string,Dictionary<string, double>> shopList = new SortedDictionary<string,Dictionary<string, double>>();
            
            string command = Console.ReadLine();

            while (command != "Revision")
            {
                string[] tokens = command.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                string shopName = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!shopList.ContainsKey(shopName))
                {
                    shopList.Add(shopName, new Dictionary<string, double>());
                }

                if (!shopList[shopName].ContainsKey(product))
                {
                    shopList[shopName].Add(product, 0);
                }

                shopList[shopName][product] = price;

                command = Console.ReadLine();
            }

            foreach (var shop in shopList)
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
