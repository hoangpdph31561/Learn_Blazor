using System.Threading.Tasks;
using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public interface ITaskAPIClient
    {
        Task<List<TaskToDoListViewModel>> GetTaskList();
        Task<TaskToDoListViewModel> GetTaskById(string TaskId);
    }
}
