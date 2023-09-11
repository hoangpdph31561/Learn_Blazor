using Microsoft.AspNetCore.Components;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class TaskDetail
    {
        [Parameter]
        public string TaskId { get; set; }
        [Inject]
        public ITaskAPIClient TaskAPIClient { get; set; }
        [Inject]
        public IConfiguration Configuration { get; set; }
        public TaskToDoListViewModel TaskViewModel { get; set; } = new TaskToDoListViewModel();
        protected async override Task OnInitializedAsync()
        {
            TaskViewModel = await TaskAPIClient.GetTaskById(TaskId);
        }
    }
}
