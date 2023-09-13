using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList_ViewModel.Enums;

namespace ToDoList_ViewModel
{
    //Kế thừa Paging tránh lặp code vì nhiều nơi cần hiển thị list
    public class TaskListSearchRequest : PagingParameter
    {
        public string? Name { get; set; }
        public Guid? AssigneeId { get; set; }
        public Priority? Priority { get; set; }
    }
}
