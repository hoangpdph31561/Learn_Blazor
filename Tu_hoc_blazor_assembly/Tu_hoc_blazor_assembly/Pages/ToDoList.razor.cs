using Blazored.Toast.Services;
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
        public IConfiguration Configuration { get; set; }
        [Inject]
        public IUserAPIClient _userAPIClient { get; set; }
        [Inject] private ITaskAPIClient _taskAPIClient { get; set; }
        [Inject]
        public IToastService ToastService { get; set; }
        private List<TaskToDoListViewModel> Tasks = new List<TaskToDoListViewModel>();
        private ChangeUser ChangeUser { get; set; }
        private Guid TaskID { get; set; }
        private List<UserViewModel> Users = new List<UserViewModel>();
        private TaskListSearchRequest TaskListSearch { get; set; } = new TaskListSearchRequest();
        private DeleteConfirmation DeleteConfirmation { get; set; }
        protected async override Task OnInitializedAsync()
        {
            Tasks = await _taskAPIClient.GetTaskList(TaskListSearch);
            Users = await _userAPIClient.GetAllUser();
        }
        private async Task SearchForm(TaskListSearchRequest requestCallBack)
        {
            TaskListSearch = requestCallBack;
            Tasks = await _taskAPIClient.GetTaskList(TaskListSearch);
        }
        public void OnDelete(Guid deleteId)
        {
            TaskID = deleteId;
            DeleteConfirmation.Show();
        }
        public async Task OnConfirmDeleteTask(bool deleteConfirm)
        {
            if(deleteConfirm)
            {
                var result =await _taskAPIClient.DeleteTask(TaskID);
                if(result)
                {
                    Tasks =await _taskAPIClient.GetTaskList(TaskListSearch);
                    ToastService.ShowInfo("Successfully delete your task");
                }
            }
        }
        private void ShowUserChange(Guid id)
        {
            ChangeUser.Show(id);
        }
        public async Task OnConfirmationChangeUser(bool isConfirm)
        {
            if(isConfirm)
            {
                Tasks = await _taskAPIClient.GetTaskList(TaskListSearch);
            }
        }
    }
    
}
