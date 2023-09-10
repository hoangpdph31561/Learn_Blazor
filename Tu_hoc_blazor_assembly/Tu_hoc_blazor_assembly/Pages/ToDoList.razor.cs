using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ToDoList_ViewModel;
using ToDoList_ViewModel.Enums;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    
    public partial class ToDoList
    {
        [Inject]
        public IUserAPIClient _userAPIClient { get; set; }
        [Inject] private ITaskAPIClient _taskAPIClient { get; set; }
        private List<TaskToDoListViewModel> Tasks = new List<TaskToDoListViewModel>();
        private List<UserViewModel> Users = new List<UserViewModel>();
        private TaskListSearchRequest TaskListSearch { get; set; } = new TaskListSearchRequest();
        protected async override Task OnInitializedAsync()
        {
            Tasks = await _taskAPIClient.GetTaskList(TaskListSearch);
            Users = await _userAPIClient.GetAllUser();
        }
        private async Task SearchForm(EditContext context)
        {
            Tasks = await _taskAPIClient.GetTaskList(TaskListSearch);
        }
    }
    
}
