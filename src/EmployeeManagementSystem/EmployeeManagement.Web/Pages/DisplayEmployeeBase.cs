namespace EmployeeManagement.Web.Pages
{
    using EmployeeManagement.Models;

    using Microsoft.AspNetCore.Components;

    public class DisplayEmployeeBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }

        [Parameter]
        public bool ShowFooter { get; set; }
    }
}
