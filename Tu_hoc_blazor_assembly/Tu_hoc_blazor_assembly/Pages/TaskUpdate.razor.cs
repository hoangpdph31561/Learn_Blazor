using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class TaskUpdate
    {
        [Inject]
        public IUserAPIClient UserAPIClient { get; set; }
        [Inject]
        public ITaskAPIClient TaskAPIClient { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string TaskId { get; set; }
        public TaskToDoListViewModel TaskViewModel { get; set; } = new TaskToDoListViewModel();
        public TaskUpdateRequest UpdateRequest { get; set; } = new TaskUpdateRequest();
        protected async override Task OnInitializedAsync()
        {
            TaskViewModel = await TaskAPIClient.GetTaskById(TaskId);
            UpdateRequest.Name = TaskViewModel.Name;
            UpdateRequest.Priority = TaskViewModel.Priority;
        }
        private async void UpdateButtonRequest(EditContext context)
        {
            var result = await TaskAPIClient.UpdateTask(TaskId, UpdateRequest);
            if (result)
            {
                ToastService.ShowSuccess($"{TaskId} has been updated successfully");
                NavigationManager.NavigateTo("/todolist");
            }
            else
            {
                ToastService.ShowError("Unable to update");
            }
        }
    }
}
