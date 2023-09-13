using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public interface IAuthenService
    {
        Task<LoginResponse> Login(LoginRequest request);
        Task Logout();
    }


}
