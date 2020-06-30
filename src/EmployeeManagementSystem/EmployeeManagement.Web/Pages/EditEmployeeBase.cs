namespace EmployeeManagement.Web.Pages
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;
    using EmployeeManagement.Web.Models;

    using Microsoft.AspNetCore.Components;

    public class EditEmployeeBase : ComponentBase
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

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Parameter]
        public string Id { get; set; }

        public List<Departament> Departaments { get; set; } = new List<Departament>();

        protected override async Task OnInitializedAsync()
        {
            this.Employee = await this.EmployeeService.GetEmployeeAsync(int.Parse(this.Id));
            this.Departaments = (await this.DepartamentService.GetDepartamentsAsync()).ToList();

            this.Mapper.Map(this.Employee, this.EditEmployeeModel);
        }

        protected async Task HandleValidSubmit()
        {
            this.Mapper.Map(this.EditEmployeeModel, this.Employee);
            var result = await this.EmployeeService.UpdateEmployeeAsync(this.Employee);

            if (result != null)
            {
                this.NavigationManager.NavigateTo("/");
            }
        }
    }
}
