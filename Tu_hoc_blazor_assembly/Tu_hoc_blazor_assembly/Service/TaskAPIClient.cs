using System.Net.Http.Json;
using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public class TaskAPIClient : ITaskAPIClient
    {
        private readonly HttpClient _httpClient;
        public TaskAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateTask(TaskCreateRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/tasks", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTask(Guid taskId)
        {
            var result = await _httpClient.DeleteAsync($"/api/tasks/{taskId}");
            return result.IsSuccessStatusCode;
        }

        public async Task<TaskToDoListViewModel> GetTaskById(string TaskId)
        {
            var result = await _httpClient.GetFromJsonAsync<TaskToDoListViewModel>($"/api/Tasks/{TaskId}");
            return result;
        }

        public async Task<List<TaskToDoListViewModel>> GetTaskList(TaskListSearchRequest request)
        {
            string url = $"/api/Tasks/?name={request.Name}&assigneeId={request.AssigneeId}&priority={request.Priority}";
            var result = await _httpClient.GetFromJsonAsync<List<TaskToDoListViewModel>>(url) ;
            return result;
        }

        public async Task<bool> UpdateTask(string TaskId, TaskUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/Tasks/{TaskId}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
