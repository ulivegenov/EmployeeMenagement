namespace EmployeeManagement.Web.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;
    using EmployeeManagement.Web.Models;

    using Microsoft.AspNetCore.Components;

    public class EmployeeFormBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartamentService DepartamentService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; } = new Employee();

        public EmployeeFormModel EmployeeFormModel { get; set; } = new EmployeeFormModel();

        [Parameter]
        public string Id { get; set; }

        public string PageHeaderText { get; set; }

        public List<Departament> Departaments { get; set; } = new List<Departament>();

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(this.Id, out int employeeId);

            if (employeeId != 0)
            {
                this.Employee = await this.EmployeeService.GetEmployeeAsync(int.Parse(this.Id));
                this.PageHeaderText = "Edit Employee";
            }
            else
            {
                this.Employee = new Employee
                {
                    DepartamentId = 1,
                    DateOfBirth = DateTime.UtcNow,
                    PhotoPath = "images/nophoto.jpg",
                };

                this.PageHeaderText = "Create Employee";
            }

            this.Departaments = (await this.DepartamentService.GetDepartamentsAsync()).ToList();
            this.Mapper.Map(this.Employee, this.EmployeeFormModel);
        }

        protected async Task HandleValidSubmit()
        {
            this.Mapper.Map(this.EmployeeFormModel, this.Employee);

            Employee result = null;

            if (this.Employee.EmployeeId != 0)
            {
                result = await this.EmployeeService.UpdateEmployeeAsync(this.Employee);
            }
            else
            {
                result = await this.EmployeeService.CreateEmployeeAsync(this.Employee);

            }

            if (result != null)
            {
                this.NavigationManager.NavigateTo("/");
            }
        }
    }
}
