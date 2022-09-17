using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<GassStation> stops = new Queue<GassStation>();
            
            for (int i = 0; i < n; i++)
            {
                int[] gasStationInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                GassStation station = new GassStation(gasStationInfo[0], gasStationInfo[1], i);
                stops.Enqueue(station);
            }

            while (true)
            {
                int currentGass = 0;
                bool validTour = true;

                for (int i = 0; i < stops.Count; i++)
                {
                    GassStation currGasStation = stops.Dequeue();
                    currentGass += currGasStation.LitersGas;
                    currentGass -= currGasStation.Distance; // Minus distance to next station if negative the loop breaks and adds curr gas station on the bottoom of the queue
                    stops.Enqueue(currGasStation);
                    if (currentGass < 0)
                    {
                        validTour = false;
                        break;
                    }
                }

                if (validTour)
                {
                    break;
                }
            }
            GassStation bestRoute = stops.Dequeue();
            Console.WriteLine(bestRoute.IndexOfStation);
        }
    }

    class GassStation
    {
        public GassStation(int litersGas, int distance, int index)
        {
            this.LitersGas = litersGas;
            this.Distance = distance;
            this.IndexOfStation = index;
        }

        public int LitersGas { get; set; }

        public int Distance { get; set; }
        public int IndexOfStation { get; set; }
    }
}
