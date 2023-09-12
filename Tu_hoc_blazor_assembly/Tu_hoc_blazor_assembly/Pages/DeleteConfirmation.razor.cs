using Microsoft.AspNetCore.Components;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class DeleteConfirmation
    {
        private bool ShowConfirmation { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; } = "Delete confirmation";
        [Parameter]
        public string ConfirmationMessage { get; set; } = "Are you sure you want to delete this task";
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }
        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }
        public async Task OnConfirmationChange(bool confirmation)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(confirmation);
        }
    }
}
