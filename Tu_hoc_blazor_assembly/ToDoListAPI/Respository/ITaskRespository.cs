using ToDoList_ViewModel;
using ToDoListAPI.Entities;
using ToDoListAPI.Model;

namespace ToDoListAPI.Respository
{
    public interface ITaskRespository
    {
        Task<List<TaskToDoListViewModel>> GetAllTask(TaskListSearchRequest request);
        Task<TaskToDoListViewModel> GetTaskByID(Guid Id);
        Task<ToDoListAPI.Entities.TaskCV> CreateNewTask(TaskModel request);
        Task Update(Guid Id, TaskUpdateRequest task);
        Task Delete(Guid Id);
        Task UpdateUser(Guid TaskId, ChangeUserRequest request);
    }
}
