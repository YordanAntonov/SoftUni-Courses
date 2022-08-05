using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(Console.ReadLine());
            Dictionary<string, KeyValuePair<string, string>> songInformation = new Dictionary<string, KeyValuePair<string, string>>();
            List<string> songList = new List<string>();

            for (int i = 0; i < iterations; i++)
            {
                string[] songInfo = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string piece = songInfo[0];
                string composer = songInfo[1];
                string key = songInfo[2];

                if (!songInformation.ContainsKey(piece))
                {
                    songInformation[piece] = new KeyValuePair<string, string>(composer, key);
                    songList.Add(piece);
                }
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string piece = tokens[1];

                switch (action)
                {
                    case "Add":
                        {
                            string composer = tokens[2];
                            string key = tokens[3];

                            if (!songInformation.ContainsKey(piece))
                            {
                                songInformation[piece] = new KeyValuePair<string, string>(composer, key);
                                songList.Add(piece);
                                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                            }
                            else
                            {
                                Console.WriteLine($"{piece} is already in the collection!");
                            }
                        }
                        break;

                    case "Remove":
                        if (songInformation.ContainsKey(piece))
                        {
                            songInformation.Remove(piece);
                            songList.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;

                    case "ChangeKey":
                        {
                            string newKey = tokens[2];
                            if (songInformation.ContainsKey(piece))
                            {
                                KeyValuePair<string, string> currSongInf = songInformation[piece];
                                string composer = currSongInf.Key;
                                songInformation[piece] = new KeyValuePair<string, string>(composer, newKey);
                                Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                            }
                        }
                        break;
                }
                command = Console.ReadLine();
            }

            foreach (string piece in songList)
            {
                Console.WriteLine($"{piece} -> Composer: {songInformation[piece].Key}, Key: {songInformation[piece].Value}");
            }
        }
    }
}
