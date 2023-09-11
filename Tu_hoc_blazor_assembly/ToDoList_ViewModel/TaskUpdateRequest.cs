using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_ViewModel.Enums;

namespace ToDoList_ViewModel
{
    public class TaskUpdateRequest
    {
        [MaxLength(20, ErrorMessage = "Name only 20 charecters")]
        [Required(ErrorMessage ="Name is needed to be refil")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must select priority")]
        public Priority? Priority { get; set; }
    }
}
