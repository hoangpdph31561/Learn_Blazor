using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Data
{
    public static class SeedingData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var UserId = Guid.NewGuid();
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = UserId,
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin1",
                    NormalizedUserName = "ADMIN1",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = hasher.HashPassword(null, "admin1"),
                    
                }) ;
        }
    }
}
