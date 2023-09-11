using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class TaskSearch
    {
        [Inject]
        public ITaskAPIClient TaskAPIClient { get; set; }
        [Inject]
        public IUserAPIClient UserAPIClient { get; set; }
        [Parameter]
        public EventCallback<TaskListSearchRequest> Onsearch { get; set; }
        public List<UserViewModel> Users { get; set; }
        public TaskListSearchRequest TaskListSearch { get; set; } = new TaskListSearchRequest();
        public TaskToDoListViewModel Tasks { get; set; } = new TaskToDoListViewModel();
        protected override async Task OnInitializedAsync()
        {
            
            Users = await UserAPIClient.GetAllUser();
        }
        private async Task SearchForm(EditContext context)
        {
            await Onsearch.InvokeAsync(TaskListSearch);
        }
    }
}
