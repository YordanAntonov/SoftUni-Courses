using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Runtime.Loader;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext dbContext = new SoftUniContext();
            Console.WriteLine(RemoveTown(dbContext));
        }

        //--Problem 03:
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            }).OrderBy(e => e.EmployeeId).AsNoTracking();

            StringBuilder sb = new StringBuilder();

            foreach (var aEmp in employees)
            {
                sb.AppendLine($"{aEmp.FirstName} {aEmp.LastName} {aEmp.MiddleName} {aEmp.JobTitle} {aEmp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 04:
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Salary > 50_000).Select(e => new
            {
                e.FirstName,
                e.Salary
            }).AsNoTracking().OrderBy(e => e.FirstName);

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 05:
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Research and Development").Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department.Name,
                e.Salary
            }).AsNoTracking().OrderBy(e => e.Salary).ThenByDescending(e => e.FirstName);

            StringBuilder sb = new StringBuilder();
            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.Name} - ${emp.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 06:
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address newAddress = new Address()
            {
                TownId = 4,
                AddressText = "Vitoshka 15"
            };


            Employee? employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = newAddress;

            context.SaveChanges();

            var employeesAddresses = context.Employees.OrderByDescending(e => e.AddressId).Take(10).Select(e => e.Address!.AddressText).AsNoTracking().ToArray();

            return string.Join(Environment.NewLine, employeesAddresses);
        }

        //--Problem 07:
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            /*Where(e => e.EmployeesProjects.Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))*/
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager!.FirstName,
                    ManagerLastName = e.Manager!.LastName,
                    Projects = e.EmployeesProjects.Where(e => e.Project.StartDate.Year >= 2001 && e.Project.StartDate.Year <= 2003).Select(p => new
                    {
                        ProjectName = p.Project.Name,
                        ProjectStartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt"),
                        ProjectEndDate = p.Project.EndDate.HasValue ? p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished"
                    })
                }).Take(10).AsNoTracking().ToArray();

            StringBuilder sb = new StringBuilder();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");
                foreach (var proj in emp.Projects)
                {
                    sb.AppendLine($"--{proj.ProjectName} - {proj.ProjectStartDate} - {proj.ProjectEndDate}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //--Problem 08:
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses.OrderByDescending(a => a.Employees.Count).ThenBy(a => a.Town!.Name).ThenBy(a => a.AddressText).Select(e => new
            {
                e.AddressText,
                e.Employees.Count,
                TownName = e.Town.Name
            }).Take(10).AsNoTracking().ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.Count} employees");
            }
            return sb.ToString().TrimEnd();
        }

        //--Problem 09:
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee147 = context.Employees.Include(e => e.EmployeesProjects).ThenInclude(ep => ep.Project).Where(ep => ep.EmployeeId == 147).FirstOrDefault();
            StringBuilder sb = new();
            sb.AppendLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");
            foreach (var item in employee147.EmployeesProjects.OrderBy(ep => ep.Project.Name))
            {
                sb.AppendLine($"{item.Project.Name}");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 10:
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departmentsEmployees = context.Departments.Where(d => d.Employees.Count > 5).Select(e => new
            {
                e.Name,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Employees = e.Employees.Select(ep => new
                {
                    ep.FirstName,
                    ep.LastName,
                    ep.JobTitle
                })
            }).OrderBy(d => d.Employees.Count()).ThenBy(d => d.Name);

            StringBuilder sb = new StringBuilder();

            foreach (var d in departmentsEmployees)
            {
                sb.AppendLine($"{d.Name} - {d.ManagerFirstName} {d.ManagerLastName}");
                foreach (var emp in d.Employees.OrderBy(ep => ep.FirstName).ThenBy(ep => ep.LastName))
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 11:
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects.OrderByDescending(p => p.StartDate).Select(p => new
            {
                p.Name,
                p.Description,
                StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
            }).Take(10).AsNoTracking().OrderBy(p => p.Name);

            StringBuilder sb = new();
            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 12:
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design" || e.Department.Name == "Marketing"
            || e.Department.Name == "Information Services").Select(e => new
            {
                e.FirstName,
                e.LastName,
                Salary = (double)e.Salary * 1.12
            }).AsNoTracking().OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

            StringBuilder sb = new();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 13:
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.FirstName.ToLower().StartsWith("sa")).Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                e.Salary
            }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).AsNoTracking().ToList();

            StringBuilder sb = new();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        //--Problem 14:
        public static string DeleteProjectById(SoftUniContext context)
        {
            var epToDelete = context.EmployeesProjects.Where(p => p.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(epToDelete);

            var project = context.Projects.Find(2);

            context.Projects.RemoveRange(project!);

            context.SaveChanges();

            var projectNames = context.Projects.Take(10).Select(p => p.Name).ToArray();

            return string.Join(Environment.NewLine, projectNames);
        }

        //--Problem 15:
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = context
                .Towns
                .First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDelete =
                context
                    .Addresses
                    .Where(a => a.TownId == townToDelete.TownId);

            int addressesCount = addressesToDelete.Count();

            IQueryable<Employee> employeesOnDeletedAddresses =
                context
                    .Employees
                    .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            foreach (var employee in employeesOnDeletedAddresses)
            {
                employee.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Remove(townToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in Seattle were deleted";

        }
    }
}
