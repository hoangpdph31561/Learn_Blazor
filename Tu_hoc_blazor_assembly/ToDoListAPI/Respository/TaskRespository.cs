using System.Data;
using ToDoList_ViewModel;
using ToDoListAPI.Data;
using ToDoListAPI.Model;

namespace ToDoListAPI.Respository
{
    public class TaskRespository : ITaskRespository
    {
        private readonly ToDoListDBContext _dbContext;
        public TaskRespository(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Entities.Task CreateNewTask(TaskModel task)
        {
            string idUser = "568f6cb7-3cb8-45d3-ae5b-64e41c22db9f";
            var newTask = new Entities.Task
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = task.Name,
                Priority = task.Priority,
                Status = task.Status,
                AssigneeId = Guid.Parse(idUser),
            };
            _dbContext.Tasks.Add(newTask);
            _dbContext.SaveChanges();
            return newTask;
        }

        public void Delete(Guid Id)
        {
            var result = _dbContext.Tasks.FirstOrDefault(x => x.Id == Id);
            _dbContext.Tasks.Remove(result);
            _dbContext.SaveChanges();
        }

        public List<TaskToDoListViewModel> GetAllTask()
        {
            return _dbContext.Tasks.Select(x => new TaskToDoListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                Status = x.Status,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                AssigneeName = x.Assignee.FirstName + " " + x.Assignee.LastName,
            }).ToList();
        }

        public Entities.Task GetTaskByID(Guid Id)
        {
            var result = _dbContext.Tasks.FirstOrDefault(x => x.Id == Id);
            return result;
        }

        public void Update(Guid Id, TaskModel task)
        {
            var result = _dbContext.Tasks.FirstOrDefault(x => x.Id == Id);
            result.Name = task.Name;
            result.Status = task.Status;
            result.Priority = task.Priority;
            result.CreatedDate = task.CreatedDate;
            _dbContext.Tasks.Update(result);
            _dbContext.SaveChanges();
        }
    }
}
