using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public interface IUserAPIClient
    {
        Task<List<UserViewModel>> GetAllUser();
    }
}
