using Microsoft.AspNetCore.Components;
using ToDoList_ViewModel;
using Tu_hoc_blazor_assembly.Service;

namespace Tu_hoc_blazor_assembly.Pages
{
    public partial class Login
    {
        [Inject]
        public IAuthenService  AuthenService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private bool IsError { get; set; }
        private string ErrorMessage { get; set; } = string.Empty;
        private LoginRequest LoginRequest { get; set; } = new LoginRequest();
        private async Task HandleLogin()
        {
            IsError = false;
            var result = await AuthenService.Login(LoginRequest);
            if(result.Successful)
            {
                NavigationManager.NavigateTo("/todolist");
            }
            else
            {
                IsError = true;
                ErrorMessage = result.Error;
                 
            }
        }
    }
}
