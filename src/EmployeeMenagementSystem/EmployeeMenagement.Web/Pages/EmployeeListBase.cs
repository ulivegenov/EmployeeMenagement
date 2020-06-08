namespace EmployeeMenagement.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EmployeeMenagement.Models;
    using EmployeeMenagement.Models.Enums;
    using Microsoft.AspNetCore.Components;

    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override Task OnInitializedAsync()
        {
            this.LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hastigs",
                Email = "David@pragimtech.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                Departament = new Departament { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/john.jpg"
            };

            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "Sam@pragimtech.com",
                DateOfBirth = new DateTime(1988, 6, 8),
                Gender = Gender.Male,
                Departament = new Departament { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/sam.jpg"
            };

            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Jonson",
                Email = "Mary@pragimtech.com",
                DateOfBirth = new DateTime(1985, 9, 10),
                Gender = Gender.Male,
                Departament = new Departament { DepartmentId = 1, DepartmentName = "HR" },
                PhotoPath = "images/mary.jpg"
            };

            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Stefany",
                LastName = "Kane",
                Email = "Stef@pragimtech.com",
                DateOfBirth = new DateTime(1992, 12, 1),
                Gender = Gender.Male,
                Departament = new Departament { DepartmentId = 1, DepartmentName = "IT" },
                PhotoPath = "images/stefany.jpg"
            };

            this.Employees = new List<Employee>() { e1, e2, e3, e4 };
        }
    }
}
