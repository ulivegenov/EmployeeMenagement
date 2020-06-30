namespace EmployeeManagement.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EmployeeManagement.Models;
    using EmployeeManagement.Models.Enums;
    using EmployeeManagement.Services.Data.Contracts;
    using Microsoft.AspNetCore.Components;

    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            this.Employees = (await this.EmployeeService.GetEmployeesAsync()).ToList();
        }
    }
}
