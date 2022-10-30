namespace MusicHub
{
    using System;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var filteredAlbums = context.Albums.Where(x => x.ProducerId == producerId).ToList();
            filteredAlbums = filteredAlbums.OrderByDescending(x => x.Price).ToList();
            StringBuilder builder = new StringBuilder();
            foreach (var item in filteredAlbums)
            {
                builder.AppendLine($"-AlbumName: {item.Name}");
                builder.AppendLine($"-ReleaseDate: {item.ReleaseDate.ToString("MM/dd/yyyy")}");
                builder.AppendLine($"-ProducerName: {item.Producer.Name}");
                builder.AppendLine($"-Songs:");
                int i = 1;
                item.Songs = item.Songs.OrderByDescending(x => x.Name).ThenBy(x => x.Writer).ToHashSet();
                foreach (var song in item.Songs)
                {
                    builder.AppendLine($"---#{i}");
                    builder.AppendLine($"---SongName: {song.Name}");
                    builder.AppendLine($"---Price: {song.Price:f2}");
                    builder.AppendLine($"---Writer: {song.Writer.Name}");
                    i++;
                }
                builder.AppendLine($"-AlbumPrice: {item.Price:f2}");
            }
            return builder.ToString().TrimEnd();
        }
        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var filteredAlbums = context.Songs
                .Include(x => x.SongPerformers)
                .ThenInclude(x => x.Performer)
                .ToList()
                .Where(x => x.Duration.TotalSeconds > duration)
                .Select(x => new
            {
                x.Name,
                Performer = x.SongPerformers.Select(e => $"{e.Performer.FirstName} {e.Performer.LastName}").FirstOrDefault(),
                x.Duration,
                Producer = x.Album.Producer.Name,
                Writer = x.Writer.Name
            })
            .OrderBy(x => x.Name)
            .ThenBy(x => x.Writer)
            .ThenBy(x => x.Performer)
            .ToList();
            StringBuilder builder = new StringBuilder();
            int i = 1;
            foreach (var item in filteredAlbums)
            {
                builder.AppendLine($"-Song #{i}");
                builder.AppendLine($"---SongName: {item.Name}");
                builder.AppendLine($"---Writer: {item.Writer}");
                builder.AppendLine($"---Performer: {item.Performer}");
                builder.AppendLine($"---AlbumProducer: {item.Producer}");
                builder.AppendLine($"---Duration: {item.Duration.ToString("c")}");
                i++;
            }
            return builder.ToString().TrimEnd();
        }
    }
}
