namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var theatres = context.Theatres
                .ToList()
                .Where(x => x.NumberOfHalls >= numbersOfHalls && x.Tickets.Count >= 20)
                .Select(x => new
                {
                    x.Name,
                    Halls = x.NumberOfHalls,
                    TotalIncome = x.Tickets.Where(e => e.RowNumber >= 1 && e.RowNumber <= 5).Sum(e => e.Price),
                    Tickets = x.Tickets.ToList().Where(e => e.RowNumber >= 1 && e.RowNumber <= 5).Select(e => new
                    {
                        e.Price,
                        e.RowNumber
                    }).OrderByDescending(e => e.Price)
                }).OrderByDescending(x => x.Halls)
                .ThenBy(x => x.Name);
            return JsonConvert.SerializeObject(theatres);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            var plays = context.Plays
                .ToList()
                .Where(x => x.Rating<=rating)
                .Select(x => new PlayDTO
                {
                    Title = x.Title,
                    Duration = x.Duration.ToString("c"),
                    Rating = (x.Rating==0)? "Premier":$"{x.Rating}",
                    Genre = x.Genre.ToString(),
                    Actors = x.Casts.Where(e => e.IsMainCharacter).Select(e => new CastDTO
                    {
                        FullName = e.FullName,
                        IsMainCharacter = $"Plays main character in '{x.Title}'."
                    }).OrderByDescending(e => e.FullName).ToList()
                }).OrderBy(x => x.Title)
                .ThenByDescending(x =>x.Genre)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<PlayDTO>), new XmlRootAttribute("Plays"));
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, plays, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
    }
}
