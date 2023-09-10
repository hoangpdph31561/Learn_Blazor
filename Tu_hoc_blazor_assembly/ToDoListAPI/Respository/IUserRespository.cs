using ToDoList_ViewModel;

namespace ToDoListAPI.Respository
{
    public interface IUserRespository
    {
        Task<List<UserViewModel>> GetAllUser();
    }
}
