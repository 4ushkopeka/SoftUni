using System;
using System.Linq;
using System.Text;
using SoftUni.Data;
using SoftUni.Models;
namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(DeleteProjectById(context));
        }
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var extracted = context.Employees.Select(a => new { a.EmployeeId, a.FirstName, a.MiddleName, a.LastName, a.JobTitle, a.Salary }).ToHashSet();
            extracted = extracted.OrderBy(a => a.EmployeeId).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in extracted) build.AppendLine($"{item.FirstName} {item.LastName} {item.MiddleName} {item.JobTitle} {item.Salary:f2}");
            return build.ToString().TrimEnd();
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var extracted = context.Employees.Where(a => a.Salary > 50000).Select(a => new { a.FirstName, a.Salary }).ToHashSet();
            extracted = extracted.OrderBy(a => a.FirstName).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in extracted) build.AppendLine($"{item.FirstName} - {item.Salary:f2}");
            return build.ToString().TrimEnd();
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var extracted = context.Employees.Where(a => a.Department.Name =="Research and Development").Select(a => new { a.FirstName, a.LastName, a.Department, a.Salary }).ToHashSet();
            extracted = extracted.OrderBy(a => a.Salary).ThenByDescending(a => a.FirstName).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in extracted) build.AppendLine($"{item.FirstName} {item.LastName} from {item.Department.Name} - ${item.Salary:f2}");
            return build.ToString().TrimEnd();
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var selectedEmployee = context.Employees.FirstOrDefault(a => a.LastName == "Nakov");
            Address ad = new Address();
            ad.TownId = 4;
            ad.AddressText = "Vitoshka 15";
            selectedEmployee.Address = ad;
            context.SaveChanges();
            var texts = context.Employees.OrderByDescending(x =>x.AddressId).Take(10).Select(x =>x.Address).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in texts) build.AppendLine($"{item.AddressText}");
            return build.ToString().TrimEnd();
        }
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var extracted = context.EmployeesProjects.Where(x => x.Project.StartDate.Year < 2004 && x.Project.StartDate.Year > 2000).Select(x => x.Employee).Take(10).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in extracted)
            {
                build.AppendLine($"{item.FirstName} {item.LastName} - Manager: {item.Manager.FirstName} {item.Manager.LastName}");
                foreach (var okto in item.EmployeesProjects)
                {
                    string endDate = okto.Project.EndDate == null ? "not finished" : okto.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt");
                    build.AppendLine($"--{okto.Project.Name} - {okto.Project.StartDate} - {endDate}");
                }
            }
            return build.ToString().TrimEnd();
        }
        public static string GetAddressesByTown(SoftUniContext context) 
        {
            var extracted = context.Addresses.OrderByDescending(x => x.Employees.Count).ThenBy(x => x.Town.Name).ThenBy(x => x.AddressText).Take(10).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in extracted) build.AppendLine($"{item.AddressText}, {item.Town.Name} - {item.Employees.Count} employees");
            return build.ToString().TrimEnd();
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var emp = context.Employees.FirstOrDefault(x => x.EmployeeId == 147);
            StringBuilder build = new StringBuilder();
            build.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
            foreach (var item in emp.EmployeesProjects.OrderBy(x => x.Project.Name)) build.AppendLine($"{item.Project.Name}");
            return build.ToString().TrimEnd();
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Where(x => x.Employees.Count > 5).OrderBy(x => x.Employees.Count).ThenBy(x => x.Name).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in departments)
            {
                build.AppendLine($"{item.Name} - {item.Manager.FirstName} {item.Manager.LastName}");
                foreach (var emp in item.Employees) build.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
            }
            return build.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(x => x.StartDate).Take(10).ToHashSet();
            projects = projects.OrderBy(x => x.Name).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in projects)
            {
                build.AppendLine($"{item.Name}");
                build.AppendLine($"{item.Description}");
                build.AppendLine($"{item.StartDate.ToString("M/d/yyyy h:mm:ss tt")}");
            }
            return build.ToString().TrimEnd();
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var upgrades = context.Employees.Where(x => x.Department.Name == "Engineering" || x.Department.Name == "Tool Design" || x.Department.Name == "Marketing" || x.Department.Name == "Information Services").ToHashSet();
            foreach (var item in upgrades) item.Salary *= 1.12M;
            upgrades = upgrades.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in upgrades) build.AppendLine($"{item.FirstName} {item.LastName} (${item.Salary:f2})");
            return build.ToString().TrimEnd();
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var shapshali = context.Employees.Where(x => x.FirstName.StartsWith("Sa")).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in shapshali.OrderBy(x => x.FirstName).ThenBy(x => x.LastName)) build.AppendLine($"{item.FirstName} {item.LastName} - {item.JobTitle} - (${item.Salary:f2})");
            return build.ToString().TrimEnd();
        }
        public static string DeleteProjectById(SoftUniContext context)
        {
            var dele = context.Projects.Find(2);
            foreach (var item in context.EmployeesProjects)
            {
                if (item.ProjectId == 2) context.EmployeesProjects.Remove(item);
            }
            context.Projects.Remove(dele);
            context.SaveChanges();
            var top = context.Projects.Take(10).ToHashSet();
            StringBuilder build = new StringBuilder();
            foreach (var item in top) build.AppendLine(item.Name);
            return build.ToString().TrimEnd();
        }
    }
}
