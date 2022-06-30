using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Defining_Simple_Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfSongs = int.Parse(Console.ReadLine());
            List<Song> songList = new List<Song>();

            for (int i = 0; i < numOfSongs; i++)
            {
                string commands = Console.ReadLine();
                string[] songProperties = commands.Split('_');
                Song song = new Song(songProperties[0], songProperties[1], songProperties[2]);
                songList.Add(song);
            }
            string typeList = Console.ReadLine();

            foreach (Song song in songList)
            {
                if (typeList == "all")
                {
                   Console.WriteLine(song.Name);
                }
                else
                {
                    if (typeList == song.TypeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }

    class Song
    {
        public Song(string typeList, string name, string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }

        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
