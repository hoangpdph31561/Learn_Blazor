using Microsoft.AspNetCore.Components;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class ChangeUser
    {

        public bool IsShow { get; set; }
        [Parameter]
        public EventCallback<bool> ChangeUserEvent { get; set; }
        [Inject]
        public IUserAPIClient UserApiClient { get; set; }
        [Inject]
        public ITaskAPIClient TaskAPIClient { get; set; }
        public Guid TaskId { get; set; }
        public List<UserViewModel> UserView { get; set; } = new List<UserViewModel>();
        public ChangeUserRequest RequestChangeUser { get; set; } = new ChangeUserRequest();
        protected override async Task OnInitializedAsync()
        {
            UserView = await UserApiClient.GetAllUser();
        }

        public void Show(Guid id)
        {
            TaskId = id;
            IsShow = true;
            StateHasChanged();
        }
        private void Hide()
        {
            IsShow = false;
            StateHasChanged();
        }

        public async Task ConfirmChange()
        {
            var result = await TaskAPIClient.UpdateUser(TaskId, RequestChangeUser);
            if(result)
            {
                IsShow = false;
                await ChangeUserEvent.InvokeAsync(true);
            }
        }
    }
}
