using System.ComponentModel.DataAnnotations;

namespace TodoListProject.Models
{
    public class TaskModel
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime TargetDate { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }

}
