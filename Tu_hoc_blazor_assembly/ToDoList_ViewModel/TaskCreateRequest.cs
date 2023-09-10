using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_ViewModel.Enums;

namespace ToDoList_ViewModel
{
    public class TaskCreateRequest
    {
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [Required]
        public Priority? Priority { get; set; }
    }
}
