namespace EmployeeManagement.Web.Pages
{
    using System.Threading.Tasks;

    using EmployeeManagement.GlobalConstants;
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

        protected string ButtonText { get; set; } = "Show Footer";
        protected string CssClass { get; set; } = "HideFooter";

        protected async override Task OnInitializedAsync()
        {
            this.Id ??= DefaultValues.DefaultId;
            this.Employee = await this.EmployeeService.GetEmployee(int.Parse(this.Id));
        }

        protected void ButtonClick()
        {
            if (this.ButtonText == "Hide Footer")
            {
                this.ButtonText = "Show Footer";
                this.CssClass = "HideFooter";
            }
            else
            {
                this.ButtonText = "Hide Footer";
                this.CssClass = null;
            }
        }
    }
}
