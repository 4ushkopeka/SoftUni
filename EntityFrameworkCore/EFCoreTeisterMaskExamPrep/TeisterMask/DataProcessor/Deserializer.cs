namespace TeisterMask.DataProcessor
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
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectDTO[]), new XmlRootAttribute("Projects"));
            var objects = (ProjectDTO[])serializer.Deserialize(new StringReader(xmlString));
            StringBuilder sb = new StringBuilder();
            ICollection<Project> projects = new List<Project>();
            ICollection<Task> tasks = new List<Task>();
            foreach (var projectDto in objects)
            {
                int taskCount = 0;
                if (!IsValid(projectDto)) { sb.AppendLine(ErrorMessage); continue; }
                bool openDateParse = DateTime.TryParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime openDateVal);
                if (!openDateParse) { sb.AppendLine(ErrorMessage); continue; }
                DateTime? dueDate = null;
                if (!String.IsNullOrEmpty(projectDto.DueDate))
                {
                    bool dueDateParse = DateTime.TryParseExact(projectDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDateVal);
                    if (!dueDateParse) { sb.AppendLine(ErrorMessage); continue; }
                    dueDate = dueDateVal;
                }
                Project project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = openDateVal,
                    DueDate = dueDate
                };
                projects.Add(project);
                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto)) { sb.AppendLine(ErrorMessage); continue; }
                    bool taskOpenDateParse = DateTime.TryParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDateVal);
                    if (!taskOpenDateParse) { sb.AppendLine(ErrorMessage); continue; }
                    bool taskDueDateParse = DateTime.TryParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDateVal);
                    if (!taskDueDateParse) { sb.AppendLine(ErrorMessage); continue; }
                    if (openDateVal.CompareTo(taskOpenDateVal)<0) { sb.AppendLine(ErrorMessage); continue; }
                    if (project.DueDate.HasValue && project.DueDate.Value.CompareTo(taskDueDateVal)>0) { sb.AppendLine(ErrorMessage); continue; }
                    ExecutionType execType = 0;
                    LabelType labelType = 0;
                    try
                    {
                        execType = (ExecutionType)Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType);
                        labelType = (LabelType)Enum.ToObject(typeof(LabelType), taskDto.LabelType);
                    }
                    catch (Exception)
                    { 
                        sb.AppendLine(ErrorMessage);
                        continue; 
                    }
                    Task task = new Task
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDateVal,
                        DueDate = taskDueDateVal,
                        ExecutionType = execType,
                        LabelType = labelType,
                        Project = project
                    };
                    taskCount++;
                    tasks.Add(task);
                }
                sb.AppendLine(String.Format(SuccessfullyImportedProject, project.Name, taskCount));
            }
            context.Projects.AddRange(projects);
            context.Tasks.AddRange(tasks);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var objects = JsonConvert.DeserializeObject<EmployeeDTO[]>(jsonString);
            var employees = new List<Employee>();
            var employeesTasks = new List<EmployeeTask>();
            StringBuilder sb = new StringBuilder();
            foreach (var empDto in objects)
            {
                int count = 0;
                if (!IsValid(empDto)) { sb.AppendLine(ErrorMessage); continue; }
                Employee emp = new Employee
                {
                    Username = empDto.Username,
                    Email = empDto.Email,
                    Phone = empDto.Phone,
                };
                employees.Add(emp);
                foreach (var taskId in empDto.Tasks.Distinct())
                {
                    if (!context.Tasks.Select(x => x.Id).Any(x => x == taskId)) { sb.AppendLine(ErrorMessage); continue; }
                    EmployeeTask empTask = new EmployeeTask
                    {
                        TaskId = taskId,
                        Employee = emp
                    };
                    count++;
                    employeesTasks.Add(empTask);
                }
                sb.AppendLine(String.Format(SuccessfullyImportedEmployee, emp.Username, count));
            }
            context.Employees.AddRange(employees);
            context.EmployeesTasks.AddRange(employeesTasks);
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