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
        

        public async Task<List<TaskToDoListViewModel>> GetTaskList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TaskToDoListViewModel>>("/api/Tasks");
            return result;
        }
    }
}
