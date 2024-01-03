
using Microsoft.EntityFrameworkCore;
using TodoListProject.Models;

namespace TodoListProject.Data

{
    public class DataContext : DbContext
    {
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
