using Microsoft.EntityFrameworkCore;
using ToDoList_ViewModel;
using ToDoListAPI.Data;

namespace ToDoListAPI.Respository
{
    public class UserRespository : IUserRespository
    {
        private readonly ToDoListDBContext _dbContext;
        public UserRespository(ToDoListDBContext dbContext)
        {
            _dbContext = dbContext; 
        }
        public async Task<List<UserViewModel>> GetAllUser()
        {
            var result = await _dbContext.Users.Select(x => new UserViewModel
            {
                UserId = x.Id,
                Name = x.FirstName + " " + x.LastName,
            }).ToListAsync();
            return result;
            
        }
    }
}
