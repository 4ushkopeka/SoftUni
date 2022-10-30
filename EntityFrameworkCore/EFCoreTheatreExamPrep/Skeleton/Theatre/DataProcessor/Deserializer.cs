namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            XmlSerializer ser = new XmlSerializer(typeof(PlayDTO[]), new XmlRootAttribute("Plays"));
            var objects = (PlayDTO[])ser.Deserialize(new StringReader(xmlString));
            ICollection<Play> plays = new List<Play>();
            StringBuilder sb = new StringBuilder();
            foreach (var playdto in objects)
            {
                if (!IsValid(playdto)) { sb.AppendLine("Invalid data!"); continue; }
                bool durationParsed = TimeSpan.TryParseExact(playdto.Duration, "c", CultureInfo.InvariantCulture, TimeSpanStyles.None, out TimeSpan durationVal);
                if (!durationParsed) { sb.AppendLine("Invalid data!"); continue; }
                if (durationVal.TotalHours<1) { sb.AppendLine("Invalid data!"); continue; }
                bool genreParsed = Enum.TryParse(playdto.Genre, true, out Genre genreVal);
                if (!genreParsed) { sb.AppendLine("Invalid data!"); continue; }
                Play play = new Play
                {
                    Title = playdto.Title,
                    Description = playdto.Description,
                    Genre = genreVal,
                    Duration = durationVal,
                    Rating = playdto.Rating,
                    Screenwriter = playdto.Screenwriter,
                };
                plays.Add(play);
                sb.AppendLine($"Successfully imported {playdto.Title} with genre {playdto.Genre} and a rating of {playdto.Rating}!");
            }
            context.Plays.AddRange(plays);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CastDTO[]), new XmlRootAttribute("Casts"));
            var objects = (CastDTO[])ser.Deserialize(new StringReader(xmlString));
            ICollection<Cast> casts = new List<Cast>();
            StringBuilder sb = new StringBuilder();
            foreach (var castDto in objects)
            {
                if (!IsValid(castDto)) { sb.AppendLine("Invalid data!"); continue; }
                Cast cast = new Cast
                {
                    FullName = castDto.FullName,
                    PhoneNumber = castDto.PhoneNumber,
                    IsMainCharacter = castDto.IsMainCharacter,
                    PlayId = castDto.PlayId
                };
                casts.Add(cast);
                string main = castDto.IsMainCharacter ? "main" : "lesser";
                sb.AppendLine($"Successfully imported actor {castDto.FullName} as a {main} character!");
            }
            context.Casts.AddRange(casts);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<TheatreDTO[]>(jsonString);
            ICollection<Theatre> theatres = new List<Theatre>();
            ICollection<Ticket> tickets = new List<Ticket>();
            StringBuilder sb = new StringBuilder();
            foreach (var theatreDto in objects)
            {
                if (!IsValid(theatreDto)) { sb.AppendLine("Invalid data!"); continue; }
                Theatre theatre = new Theatre
                {
                    Name = theatreDto.Name,
                    NumberOfHalls = theatreDto.NumberOfHalls,
                    Director = theatreDto.Director
                };
                theatres.Add(theatre);
                int totalNumber = 0;
                foreach (var ticketDto in theatreDto.Tickets)
                {
                    if (!IsValid(ticketDto)) { sb.AppendLine("Invalid data!"); continue; }
                    Ticket ticket = new Ticket 
                    { 
                        Price = ticketDto.Price,
                        RowNumber = ticketDto.RowNumber,
                        PlayId = ticketDto.PlayId,
                        Theatre = theatre
                    };
                    tickets.Add(ticket);
                    totalNumber++;
                }
                sb.AppendLine($"Successfully imported theatre {theatreDto.Name} with #{totalNumber} tickets!");
            }
            context.Theatres.AddRange(theatres);
            context.Tickets.AddRange(tickets);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
