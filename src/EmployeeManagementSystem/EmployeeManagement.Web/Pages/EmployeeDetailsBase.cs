namespace EmployeeManagement.Web.Pages
{
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;

    using Microsoft.AspNetCore.Components;

    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Employee Employee { get; set; } = new Employee();

        protected async override Task OnInitializedAsync()
        {
            this.Employee = await this.EmployeeService.GetEmployee(int.Parse(this.Id));
        }
    }
}
