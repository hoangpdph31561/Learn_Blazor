using System.Net.Http.Json;
using ToDoList_ViewModel;

namespace Tu_hoc_blazor_assembly.Service
{
    public class UserAPIClient : IUserAPIClient
    {
        private readonly HttpClient _httpClient;
        public UserAPIClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<UserViewModel>> GetAllUser()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserViewModel>>("/api/users");
            return result;
        }
    }
}
