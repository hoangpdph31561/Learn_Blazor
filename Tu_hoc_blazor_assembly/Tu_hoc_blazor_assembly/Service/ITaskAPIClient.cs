
using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public interface ITaskAPIClient
    {
        Task<List<TaskToDoListViewModel>> GetTaskList(TaskListSearchRequest request);
        Task<TaskToDoListViewModel> GetTaskById(string TaskId);
        Task<bool> CreateTask(TaskCreateRequest request);
        Task<bool> UpdateTask(string TaskId, TaskUpdateRequest request);
        Task<bool> DeleteTask(Guid taskId);
    }
}
