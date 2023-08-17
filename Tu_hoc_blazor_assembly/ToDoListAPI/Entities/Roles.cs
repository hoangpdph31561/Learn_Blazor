using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Entities
{
    public class Roles  : IdentityRole<Guid>
    {
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
    }
}
