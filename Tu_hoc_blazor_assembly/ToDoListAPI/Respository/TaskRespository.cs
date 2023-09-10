using Microsoft.EntityFrameworkCore;
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
        public async Task<Entities.TaskCV> CreateNewTask(TaskModel task)
        {
            string idUser = "568f6cb7-3cb8-45d3-ae5b-64e41c22db9f";
            var newTask = new Entities.TaskCV
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = task.Name,
                Priority = task.Priority,
                Status = task.Status,
                AssigneeId = Guid.Parse(idUser),
            };
            _dbContext.Tasks.Add(newTask);
            await _dbContext.SaveChangesAsync();
            return newTask;
        }

        public async Task Delete(Guid Id)
        {
            var result = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
             _dbContext.Tasks.Remove(result);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<TaskToDoListViewModel>> GetAllTask()
        {
            return await _dbContext.Tasks.Select(x => new TaskToDoListViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                Priority = x.Priority,
                Status = x.Status,
                AssigneeId = x.AssigneeId,
                CreatedDate = x.CreatedDate,
                AssigneeName = x.Assignee.FirstName + " " + x.Assignee.LastName,
            }).ToListAsync();
        }

        public async Task<Entities.TaskCV> GetTaskByID(Guid Id)
        {
            var result =await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            return result;
        }

        public async Task Update(Guid Id, TaskModel task)
        {
            var result = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            result.Name = task.Name;
            result.Status = task.Status;
            result.Priority = task.Priority;
            result.CreatedDate = task.CreatedDate;
            _dbContext.Tasks.Update(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
