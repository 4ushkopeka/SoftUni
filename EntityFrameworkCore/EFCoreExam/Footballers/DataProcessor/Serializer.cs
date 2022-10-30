namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            var coaches = context.Coaches
                .ToList()
                .Where(x => x.Footballers.Count!=0)
                .Select(x => new CoachDTO
                {
                    FootballersCount = x.Footballers.Count,
                    CoachName = x.Name,
                    Footballers = x.Footballers.Select(e => new FootballerDTO
                    {
                        Name = e.Name,
                        Position = e.PositionType.ToString()
                    }).OrderBy(e => e.Name)
                    .ToList()
                }).OrderByDescending(e => e.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<CoachDTO>), new XmlRootAttribute("Coaches"));
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, coaches, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .ToList()
                .Where(x => x.TeamsFootballers.Select(e => e.Footballer).Any(e => e.ContractStartDate >= date))
                .Select(e => new
                {
                    e.Name,
                    Footballers = e.TeamsFootballers
                    .Select(e => e.Footballer)
                    .Where(e => e.ContractStartDate >= date)
                    .OrderByDescending(e => e.ContractEndDate)
                    .ThenBy(e => e.Name)
                    .Select(e => new
                    {
                        FootballerName = e.Name,
                        ContractStartDate = e.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                        ContractEndDate = e.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                        BestSkillType = e.BestSkillType.ToString(),
                        PositionType = e.PositionType.ToString()
                    }).ToList()
                }).OrderByDescending(x => x.Footballers.Count)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();
            return JsonConvert.SerializeObject(teams, Formatting.Indented);
        }
    }
}
