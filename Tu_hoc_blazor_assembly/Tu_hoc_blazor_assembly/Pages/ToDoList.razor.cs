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
        private MetaData MetaData { get; set; } = new MetaData();
        protected async override Task OnInitializedAsync()
        {
            await GetTask();
            Users = await _userAPIClient.GetAllUser();
        }
        private async Task SearchForm(TaskListSearchRequest requestCallBack)
        {
            TaskListSearch = requestCallBack;
            await GetTask();
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
                    await GetTask();
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
                await GetTask();
            }
        }
        private async Task GetTask()
        {
            var pagingRespone = await _taskAPIClient.GetTaskList(TaskListSearch);
            Tasks = pagingRespone.Items;
            MetaData = pagingRespone.MetaData;
        }
        private async Task PageChoose(int page)
        {
            TaskListSearch.PageNumber = page;
            await GetTask();
        }
    }
    
}
