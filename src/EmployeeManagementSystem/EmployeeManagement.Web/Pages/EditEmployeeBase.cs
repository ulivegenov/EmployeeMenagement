namespace EmployeeManagement.Web.Pages
{
    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;
    using Microsoft.AspNetCore.Components;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartamentService DepartamentService { get; set; }

        public Employee Employee { get; set; } = new Employee();

        [Parameter]
        public string Id { get; set; }

        public List<Departament> Departaments { get; set; } = new List<Departament>();

        protected override async Task OnInitializedAsync()
        {
            this.Employee = await this.EmployeeService.GetEmployee(int.Parse(this.Id));
            this.Departaments = (await this.DepartamentService.GetDepartamentsAsync()).ToList();
        }
    }
}
