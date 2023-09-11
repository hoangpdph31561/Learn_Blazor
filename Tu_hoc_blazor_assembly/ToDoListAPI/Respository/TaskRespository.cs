using Microsoft.EntityFrameworkCore;
using System.Data;
using ToDoList_ViewModel;
using ToDoList_ViewModel.Enums;
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
        public async Task<Entities.TaskCV> CreateNewTask(TaskModel request)
        {
            string idUser = "568f6cb7-3cb8-45d3-ae5b-64e41c22db9f";
            var newTask = new Entities.TaskCV
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = request.Name,
                Priority = request.Priority,
                Status = Status.New,
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

        public async Task<List<TaskToDoListViewModel>> GetAllTask(TaskListSearchRequest request)
        {
            var querry = _dbContext.Tasks.Include(x => x.Assignee).AsQueryable();
            if (!string.IsNullOrEmpty(request.Name))
            {
                querry = querry.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
            }
            if(request.AssigneeId.HasValue)
            {
                querry = querry.Where(x => x.Assignee.Id == request.AssigneeId.Value);
            }
            if(request.Priority.HasValue)
            {
                querry = querry.Where(x => x.Priority == request.Priority.Value);

            }
            return await querry.Select(x => new TaskToDoListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                AssigneeId = x.AssigneeId,
                Priority = x.Priority,
                AssigneeName = x.Assignee.FirstName + " " + x.Assignee.LastName,
                CreatedDate = x.CreatedDate,
                Status = x.Status,
            }).ToListAsync();
        }

        public async Task<TaskToDoListViewModel> GetTaskByID(Guid Id)
        {
            var result =await _dbContext.Tasks.Include(x => x.Assignee).FirstOrDefaultAsync(x => x.Id == Id);
            if(result == null)
            {
                return null;
            }
            else
            {
                var finalResult = new TaskToDoListViewModel()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Priority = result.Priority,
                    Status = result.Status,
                    AssigneeId = result.AssigneeId,
                    CreatedDate = result.CreatedDate,
                    AssigneeName = result.Assignee.FirstName + " " + result.Assignee.LastName,
                };
                return finalResult;
            }
        }

        public async Task Update(Guid Id, TaskUpdateRequest task)
        {
            var result = await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == Id);
            result.Name = task.Name;
            result.Priority = task.Priority== null? Priority.Low :(Priority) task.Priority;
            _dbContext.Tasks.Update(result);
            await _dbContext.SaveChangesAsync();
        }
    }
}
