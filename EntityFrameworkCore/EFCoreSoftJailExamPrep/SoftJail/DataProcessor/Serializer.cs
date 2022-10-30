namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ExportDTO;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var allPrisoners = context.Prisoners.ToList();
            var neededPrisoners = new List<Prisoner>();
            foreach (var item in ids) neededPrisoners.Add(allPrisoners.FirstOrDefault(x => x.Id == item));
            var result = neededPrisoners
                .Select(x => new
                {
                    x.Id,
                    Name = x.FullName,
                    CellNumber = x.Cell.CellNumber,
                    Officers = x.PrisonerOfficers.Select(x => new
                    {
                        OfficerName = x.Officer.FullName,
                        Department = x.Officer.Department.Name
                    }).OrderBy(x => x.OfficerName).ToList(),
                    TotalOfficerSalary = Math.Round(x.PrisonerOfficers.Select(x => x.Officer).Sum(e => e.Salary),2)
                }).OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();
            return JsonConvert.SerializeObject(result);
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            var prisonerNames = prisonersNames.Split(',').ToArray();
            var neededPrisoners = new List<Prisoner>();
            foreach (var item in prisonerNames) neededPrisoners.Add(context.Prisoners.FirstOrDefault(x => x.FullName == item));
            var prisoners = neededPrisoners
                .Select(x => new PrisonerDTO
                {
                    Id = x.Id,
                    Name = x.FullName,
                    IncarcerationDate = x.IncarcerationDate.ToString("yyyy-MM-dd"),
                    EncryptedMessages = x.Mails.Select(e => new MessageDTO 
                    { 
                        Description = string.Join("",e.Description.Reverse())
                    }).ToList(),
                }).OrderBy(x => x.Name)
                .ThenBy(x => x.Id)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlRootAttribute root = new XmlRootAttribute("Prisoners");
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<PrisonerDTO>));
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, prisoners, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }
    }
}