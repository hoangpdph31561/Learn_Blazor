using ToDoList_ViewModel.Enums;


namespace ToDoListAPI.Model
{
    public class TaskModel
    {
        public string Name { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
