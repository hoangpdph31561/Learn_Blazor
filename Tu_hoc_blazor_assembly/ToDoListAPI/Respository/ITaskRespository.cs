using ToDoListAPI.Entities;
using ToDoListAPI.Model;

namespace ToDoListAPI.Respository
{
    public interface ITaskRespository
    {
        List<ToDoListAPI.Entities.Task> GetAllTask();
        ToDoListAPI.Entities.Task GetTaskByID(Guid Id);
        ToDoListAPI.Entities.Task CreateNewTask(TaskModel task);
        void Update(Guid Id, TaskModel task);
        void Delete(Guid Id);
    }
}
