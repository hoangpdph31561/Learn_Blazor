using Microsoft.AspNetCore.Components;
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
        private TaskCreateRequest CreateRequest { get; set; } = new TaskCreateRequest();
    }
}
