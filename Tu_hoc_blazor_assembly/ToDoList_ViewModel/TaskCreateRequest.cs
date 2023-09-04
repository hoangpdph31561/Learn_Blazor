using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_ViewModel.Enums;

namespace ToDoList_ViewModel
{
    public class TaskCreateRequest
    {
        
        public string Name { get; set; }
        public Priority? Priority { get; set; }
    }
}
