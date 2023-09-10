using System.ComponentModel.DataAnnotations.Schema;
using ToDoList_ViewModel.Enums;


namespace ToDoListAPI.Entities
{
    public class TaskCV
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AssigneeId { get; set; }
        [ForeignKey(nameof(AssigneeId))]
        public User Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
