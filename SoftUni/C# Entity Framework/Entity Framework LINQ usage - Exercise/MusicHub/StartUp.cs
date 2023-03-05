namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            string result = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new();

            var albumInfo = context.Albums.Where(a => a.ProducerId.HasValue && a.ProducerId == producerId).ToList()
                .OrderByDescending(a => a.Price).Select(a => new
            {
                AlbumName = a.Name,
                ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyy", CultureInfo.InvariantCulture),
                ProducerName = a.Producer.Name,
                Songs = a.Songs.Select(s => new
                {
                    SongName = s.Name,
                    s.Price,
                    Writer = s.Writer.Name,
                }).OrderByDescending(s => s.SongName).ThenBy(w => w.Writer).ToList(),
                AlbumPrice = a.Price
            }).ToList();


            foreach (var a in albumInfo)
            {
                sb.AppendLine($"-AlbumName: {a.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                int numberGen = 1;

                foreach (var s in a.Songs)
                {
                    sb.AppendLine($"---#{numberGen}");
                    sb.AppendLine($"---SongName: {s.SongName}");
                    sb.AppendLine($"---Price: {s.Price:f2}");
                    sb.AppendLine($"---Writer: {s.Writer}");

                    numberGen++;
                }

                sb.AppendLine($"-AlbumPrice: {a.AlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new();

            var songInfo = context.Songs.AsEnumerable().Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    s.Name,
                    Performers = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").OrderBy(p => p).ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c")
                }).OrderBy(s => s.Name).ThenBy(s => s.WriterName)
                .ToArray();

            int songNUm = 1;
            foreach (var s in songInfo)
            {
                sb.AppendLine($"-Song #{songNUm}");
                sb.AppendLine($"---SongName: {s.Name}");
                sb.AppendLine($"---Writer: {s.WriterName}");

                foreach (var performer in s.Performers)
                {
                  sb.AppendLine($"---Performer: {performer}");
                }
                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.Duration}");

                songNUm++;
            }        

            return sb.ToString().TrimEnd();
        }
    }
}
