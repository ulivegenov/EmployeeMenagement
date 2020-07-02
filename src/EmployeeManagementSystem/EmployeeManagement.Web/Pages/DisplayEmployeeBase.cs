namespace EmployeeManagement.Web.Pages
{
    using System.Threading.Tasks;

    using EmployeeManagement.Models;
    using EmployeeManagement.Services.Data.Contracts;

    using Microsoft.AspNetCore.Components;

    public class DisplayEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }

        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }

        protected async Task Delete_Click()
        {
            await this.EmployeeService.DeleteEmployeeAsync(this.Employee.EmployeeId);
            await this.OnEmployeeDeleted.InvokeAsync(this.Employee.EmployeeId);
        }
    }
}
