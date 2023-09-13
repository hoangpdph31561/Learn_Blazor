using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Data
{
    public class ToDoListDBContext : IdentityDbContext<User,Roles,Guid>
    {
        public ToDoListDBContext(DbContextOptions<ToDoListDBContext> options) : base(options)
        {
            
        }
        public DbSet<ToDoListAPI.Entities.TaskCV> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>();
            builder.Entity<IdentityUserRole<Guid>>().HasKey(x => new { x.UserId, x.RoleId });
            builder.Entity<IdentityUserLogin<Guid>>().HasKey(x => x.UserId);

            builder.Entity<IdentityRoleClaim<Guid>>();
            builder.Entity<IdentityUserToken<Guid>>().HasKey(x => x.UserId);
            builder.Seed();
        }
    }
}
