using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList_ViewModel;
using ToDoListAPI.Model;
using ToDoListAPI.Respository;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRespository _taskRespository;
        public TaskController(ITaskRespository taskRespository)
        {
            _taskRespository = taskRespository;
        }
        [HttpGet]
        public IActionResult GetAllTask()
        {
            var result = _taskRespository.GetAllTask();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetByIDTask(Guid id)
        {
            try
            {
                var result = _taskRespository.GetTaskByID(id);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest("Something went wrong");
            }
        }
        [HttpPost]
        public IActionResult CreateNewTask(TaskCreateRequest request)
        {
            try
            {
                var task = _taskRespository.CreateNewTask(new TaskModel()
                {
                    Name = request.Name,
                    Priority = (ToDoList_ViewModel.Enums.Priority) request.Priority,
                    Status = ToDoList_ViewModel.Enums.Status.Open,
                    CreatedDate = DateTime.Now,
                    
                });
                return Ok(task);
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask(Guid id, [FromForm]TaskModel task)
        {
            try
            {
                var result = _taskRespository.GetTaskByID(id);
                if(result == null )
                {
                    return NotFound();
                }
                _taskRespository.Update(id, task);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(Guid id)
        {
            try
            {
                var result = _taskRespository.GetTaskByID(id);
                if(result == null)
                {
                    return NotFound();
                }
                _taskRespository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }
    }
}
