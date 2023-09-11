using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class CreateTask
    {
        [Inject]
        public IUserAPIClient  UserApiClient { get; set; }
        [Inject]
        public ITaskAPIClient TaskAPIClient { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        private TaskCreateRequest CreateRequest { get; set; } = new TaskCreateRequest();
        private async Task CreateNewTask(EditContext context)
        {
            var result = await TaskAPIClient.CreateTask(CreateRequest);
            if(result)
            {
                ToastService.ShowSuccess($"{CreateRequest.Name} has been created successfully");
                NavigationManager.NavigateTo("/todolist");
            }
            else
            {
                ToastService.ShowError("Unable to create new task");
            }
        }
    }
}
