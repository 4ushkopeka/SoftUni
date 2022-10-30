namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDTO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<DepartmentDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            ICollection<Department> departments = new List<Department>();
            foreach (var item in dtos)
            {
                if (!IsValid(item)) { sb.AppendLine("Invalid Data"); continue; }
                else if(!item.Cells.Any()) { sb.AppendLine("Invalid Data"); continue; }
                else if(item.Cells.Any(x => !IsValid(x))) { sb.AppendLine("Invalid Data"); continue; }
                sb.AppendLine($"Imported {item.Name} with {item.Cells.Count} cells");
                List<Cell> cells  = new List<Cell>();
                foreach (var cell in item.Cells)
                {
                    Cell c = new Cell
                    {
                        CellNumber = cell.CellNumber,
                        HasWindow = cell.HasWindow
                    };
                    cells.Add(c);
                }
                context.Cells.AddRange(cells);
                Department dep = new Department() 
                { 
                    Name = item.Name,
                    Cells = cells.ToHashSet()
                };
                context.Departments.Add(dep);
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var dtos = JsonConvert.DeserializeObject<PrisonerDTO[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            ICollection<Prisoner> departments = new List<Prisoner>();
            foreach (var item in dtos)
            {
                if (!IsValid(item)) { sb.AppendLine("Invalid Data"); continue; }
                else if (item.Bail<=0) { sb.AppendLine("Invalid Data"); continue; }
                else if (!Regex.IsMatch(item.Nickname, @"^The\s[A-Z]{1}[a-z]*$")) { sb.AppendLine("Invalid Data"); continue; }
                else if (item.Mails.Any(x => !IsValid(x))) { sb.AppendLine("Invalid Data"); continue; }
                else if (item.Mails.Any(x => !Regex.IsMatch(x.Address, @"^[A-Za-z0-9\s]*\sstr\.$"))) { sb.AppendLine("Invalid Data"); continue; }
                sb.AppendLine($"Imported {item.FullName} {item.Age} years old");
                List<Mail> mails = new List<Mail>();
                DateTime incarDate;
                DateTime? releDatee = null;
                if (!DateTime.TryParseExact(item.IncarcerationDate, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None, 
                    out incarDate)) { sb.AppendLine("Invalid Data"); continue; }
                if (!String.IsNullOrEmpty(item.ReleaseDate)) 
                {
                    bool reledate = DateTime.TryParseExact(item.ReleaseDate,
                    "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime releDateVal);
                    if (!reledate) { sb.AppendLine("Invalid Data"); continue; }
                    releDatee = releDateVal;
                }
                foreach (var cell in item.Mails)
                {
                    Mail c = new Mail
                    {
                        Description = cell.Description,
                        Sender = cell.Sender,
                        Address = cell.Address
                    };
                    mails.Add(c);
                }
                context.Mails.AddRange(mails);
                Prisoner dep = new Prisoner
                {
                    FullName = item.FullName,
                    Nickname = item.Nickname,
                    Age = item.Age,
                    IncarcerationDate = incarDate,
                    ReleaseDate = releDatee,
                    Bail = item.Bail,
                    CellId = item.CellId,
                    Mails = mails
                };
                context.Prisoners.Add(dep);
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            XmlSerializer ser = new XmlSerializer(typeof(OfficerDTO[]), new XmlRootAttribute("Officers"));
            var objects = (OfficerDTO[])ser.Deserialize(new StringReader(xmlString));
            StringBuilder sb = new StringBuilder();
            ICollection<Officer> departments = new List<Officer>();
            foreach (var item in objects)
            {
                if (!IsValid(item)) { sb.AppendLine("Invalid Data"); continue; }
                if (item.Money<0) { sb.AppendLine("Invalid Data"); continue; }
                bool posParse = Enum.TryParse(item.Position, true, out Position position);
                if (!posParse) { sb.AppendLine("Invalid Data"); continue; }
                bool WepParse = Enum.TryParse(item.Weapon, true, out Weapon weapon);
                if (!WepParse) { sb.AppendLine("Invalid Data"); continue; }
                sb.AppendLine($"Imported {item.Name} ({item.Prisoners.Count} prisoners)");
                Officer offi = new Officer 
                { 
                    FullName = item.Name,
                    Salary = item.Money,
                    Position = position,
                    Weapon = weapon,
                    DepartmentId = item.DepartmentId
                };
                context.Officers.Add(offi);
                foreach (var prisoner in item.Prisoners.Select(x => x.PrisonerId).Distinct())
                {
                    OfficerPrisoner relate = new OfficerPrisoner 
                    { 
                        PrisonerId = prisoner,
                        Officer = offi
                    };
                    context.OfficersPrisoners.Add(relate);
                }
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}