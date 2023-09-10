using Microsoft.AspNetCore.Components;
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
        private TaskListSearch TaskListSearch { get; set; } = new TaskListSearch();
        protected async override Task OnInitializedAsync()
        {
            Tasks = await _taskAPIClient.GetTaskList();
            Users = await _userAPIClient.GetAllUser();
        }
    }
    public class TaskListSearch
    {
        public string Name { get; set; }
        public Guid AssigneeId { get; set; }
        public Priority  Priority { get; set; }
    }
}
