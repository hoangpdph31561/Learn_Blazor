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
        [MaxLength(20,ErrorMessage = "You cannot fill more than 20 charecters")]
        [Required(ErrorMessage ="You must enter your task name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please select your task priority")]
        public Priority? Priority { get; set; }
    }
}
