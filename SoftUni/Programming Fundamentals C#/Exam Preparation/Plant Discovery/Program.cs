using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> plantRarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> plantScore = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputLine = Console.ReadLine().Split(new[] { "<->" }, StringSplitOptions.RemoveEmptyEntries);
                string plantName = inputLine[0];
                int plantRere = int.Parse(inputLine[1]);

                if (!plantRarity.ContainsKey(plantName) && !plantScore.ContainsKey(plantName))
                {
                    plantRarity.Add(plantName, plantRere);
                    plantScore.Add(plantName, new List<double>());
                }
                else
                {
                    plantRarity[plantName] = plantRere;
                }

            }

            string secondInput = "";

            while ((secondInput = Console.ReadLine()) != "Exhibition")
            {
                string[] plantCmds = secondInput.Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries);
                string cmd = plantCmds[0];
                string[] plantInfo = plantCmds[1].Split(new[] {" - "}, StringSplitOptions.RemoveEmptyEntries);
                string plantName = plantInfo[0];
                if (!plantRarity.ContainsKey(plantName) && !plantScore.ContainsKey(plantName))
                {
                    Console.WriteLine("error");
                    continue;
                }

                switch (cmd)
                {
                    case "Rate":
                        double plantRating = double.Parse(plantInfo[1]);
                        plantScore[plantName].Add(plantRating);
                        break;
                    case "Update":
                        int newRarity = int.Parse(plantInfo[1]);
                        plantRarity[plantName] = newRarity;
                        break;
                    case "Reset":
                        plantScore[plantName].Clear();
                        break;
                }

            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plantRarity)
            {
                double avgScore = 0.00;
                foreach (var plntScore in plantScore)
                {
                    if (plantScore[plntScore.Key].Count <= 0)
                    {
                        plantScore[plntScore.Key].Add(0.00);
                    }
                    else
                    {
                        avgScore = plantScore[plntScore.Key].Average();
                    }

                    if (plant.Key == plntScore.Key)
                    {
                        Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value}; Rating: {avgScore:f2}");
                        continue;
                    }
                }
            }
        }
    }
}
