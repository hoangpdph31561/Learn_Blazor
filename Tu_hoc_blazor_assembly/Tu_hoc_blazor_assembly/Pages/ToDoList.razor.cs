using Microsoft.AspNetCore.Components;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    
    public partial class ToDoList
    {
        [Inject] private ITaskAPIClient _taskAPIClient { get; set; }
        private List<TaskToDoListViewModel> Tasks = new List<TaskToDoListViewModel>();
        protected async override Task OnInitializedAsync()
        {
            Tasks = await _taskAPIClient.GetTaskList();
        }
    }
}
