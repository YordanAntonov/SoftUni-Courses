using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_ParkingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // We create Dictrionary with <string, string>
            //# 1 if cmd == "register" =>
            // - We have to check if the Dictionary already has the name of the user
            // -If it contains it => User is already registered with {license number} Else => User succesfuli register with {name} and {license plate}
            int numOfCommands = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingUsers = new Dictionary<string, string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string cmd = input[0];
                string username = input[1];

                switch (cmd)
                {
                    case "register":
                        string licensePlate = input[2];

                        if (!parkingUsers.ContainsKey(username))
                        {
                            parkingUsers.Add(username, licensePlate);
                            Console.WriteLine($"{username} registered {licensePlate} successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        }
                        break;

                    case "unregister":
                        if (!parkingUsers.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        else
                        {
                            parkingUsers.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                }
            }

            foreach (KeyValuePair<string, string> user in parkingUsers)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
