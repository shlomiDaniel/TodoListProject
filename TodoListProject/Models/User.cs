using System.ComponentModel.DataAnnotations;

namespace TodoListProject.Models
{
    public class User
    {
        public User() { 
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Tasks = new List<TaskModel>();

        }
        
        public int Id { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }       
        public List<TaskModel>? Tasks { get; set; }    
    }
}
