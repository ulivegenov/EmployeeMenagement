namespace CustomComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Components;
    
    public class ConfirmBase : ComponentBase
    {
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete Confirmation";

        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete?";

        [Parameter]
        public string CancelButtonName { get; set; } = "Cancel";

        [Parameter]
        public string ConfirmationButtonName { get; set; } = "Delete";

        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        protected bool ShowConfirmation { get; set; }

        public void Show()
        {
            this.ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChange(bool value)
        {
            this.ShowConfirmation = false;
            await this.ConfirmationChanged.InvokeAsync(value);
        }
    }
}
