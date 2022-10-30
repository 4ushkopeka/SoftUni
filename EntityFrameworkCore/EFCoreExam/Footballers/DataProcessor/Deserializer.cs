namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            XmlSerializer ser = new XmlSerializer(typeof(CoachDTO[]), new XmlRootAttribute("Coaches"));
            var objects = (CoachDTO[])ser.Deserialize(new StringReader(xmlString));
            StringBuilder sb = new StringBuilder();
            var coaches = new List<Coach>();
            var footballers = new List<Footballer>();
            foreach (var coachDto in objects)
            {
                int footballersCount = 0;
                if (!IsValid(coachDto)) { sb.AppendLine(ErrorMessage); continue; }
                Coach coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality
                };
                coaches.Add(coach);
                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto)) { sb.AppendLine(ErrorMessage); continue; }
                    bool startDateParse = DateTime.TryParseExact(footballerDto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDateVal);
                    if (!startDateParse) { sb.AppendLine(ErrorMessage); continue; }
                    bool endDateParse = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDateVal);
                    if (!endDateParse) { sb.AppendLine(ErrorMessage); continue; }
                    if (startDateVal.CompareTo(endDateVal)>0) { sb.AppendLine(ErrorMessage); continue; }
                    PositionType posType;
                    BestSkillType skillType;
                    try
                    {
                        posType = (PositionType)Enum.ToObject(typeof(PositionType), footballerDto.PositionType);
                        skillType = (BestSkillType)Enum.ToObject(typeof(BestSkillType), footballerDto.BestSkillType);
                    }
                    catch (Exception)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    Footballer footballer = new Footballer
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = startDateVal,
                        ContractEndDate = endDateVal,
                        PositionType = posType,
                        BestSkillType = skillType,
                        Coach = coach
                    };
                    footballers.Add(footballer);
                    footballersCount++;
                }
                sb.AppendLine(String.Format(SuccessfullyImportedCoach, coach.Name, footballersCount));
            }
            context.Coaches.AddRange(coaches);
            context.Footballers.AddRange(footballers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<TeamDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var teams = new List<Team>();
            var teamsF = new List<TeamFootballer>();
            foreach (var teamDto in objects)
            {
                int count = 0;
                if (!IsValid(teamDto)) { sb.AppendLine(ErrorMessage); continue; }
                if (teamDto.Trophies<=0) { sb.AppendLine(ErrorMessage); continue; }
                Team team = new Team
                {
                    Name=teamDto.Name,
                    Nationality=teamDto.Nationality,
                    Trophies=teamDto.Trophies,
                };
                teams.Add(team);
                foreach (var footballerId in teamDto.Footballers.Distinct())
                {
                    if (!context.Footballers.Select(x => x.Id).Any(x => x == footballerId)) { sb.AppendLine(ErrorMessage); continue; }
                    TeamFootballer tf = new TeamFootballer
                    {
                        Team = team,
                        FootballerId = footballerId
                    };
                    count++;
                    teamsF.Add(tf); 
                }
                sb.AppendLine(String.Format(SuccessfullyImportedTeam, team.Name, count));
            }
            context.Teams.AddRange(teams);
            context.TeamsFootballers.AddRange(teamsF);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
