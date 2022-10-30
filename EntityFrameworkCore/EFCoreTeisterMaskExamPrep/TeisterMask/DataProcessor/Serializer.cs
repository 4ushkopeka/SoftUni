namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(x => x.Tasks.Any())
                .ToList()
                .Select(x => new ProjectDTO
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = (x.DueDate!=null)? "Yes":"No",
                    Tasks = x.Tasks.Select(e => new TaskDTO
                    {
                        Name = e.Name,
                        LabelType = e.LabelType.ToString()
                    }).OrderBy(e => e.Name).ToList()
                }).OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToList();
            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(String.Empty, String.Empty);
            XmlSerializer serialize = new XmlSerializer(typeof(List<ProjectDTO>), new XmlRootAttribute("Projects"));
            StringWriter writer = new StringWriter(sb);
            serialize.Serialize(writer, projects, xmlns);
            writer.Dispose();
            return sb.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .ToList()
                .Where(x => x.EmployeesTasks.Select(e => e.Task).Any(e => e.OpenDate.CompareTo(date) >= 0))
                .Select(x => new
                {
                    x.Username,
                    Tasks = x.EmployeesTasks.ToList()
                    .Where(e => e.Task.OpenDate.CompareTo(date) >= 0)
                    .OrderByDescending(e => e.Task.DueDate)
                    .ThenBy(e => e.Task.Name)
                    .Select(e => new
                    {
                        TaskName = e.Task.Name,
                        OpenDate = e.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                        DueDate = e.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                        LabelType = e.Task.LabelType.ToString(),
                        ExecutionType = e.Task.ExecutionType.ToString()
                    })
                    .ToList()
                }).OrderByDescending(x => x.Tasks.Count)
                .ThenBy(x => x.Username)
                .Take(10).ToList();
            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }
    }
}