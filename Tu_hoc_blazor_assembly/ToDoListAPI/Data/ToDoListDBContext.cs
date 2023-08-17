using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Data
{
    public class ToDoListDBContext : IdentityDbContext<User,Roles,Guid>
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options)
        {
            
        }
        public DbSet<ToDoListAPI.Entities.Task> Tasks { get; set; }
    }
}
