using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListProject.Data;
using TodoListProject.Models;

namespace TodoListProject.Services
{
    public class TasksService
    {
        private readonly DataContext _context;

        public TasksService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TaskModel>> GetTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel?> GetTaskAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateTaskAsync(int id, TaskModel task)
        {
            var taskToUpdate = await _context.Tasks.FindAsync(id);

            if (taskToUpdate == null)
            {
                return false;
            }

            taskToUpdate.Title = task.Title;
            taskToUpdate.Description = task.Description;
            taskToUpdate.IsCompleted = task.IsCompleted;
            taskToUpdate.TargetDate = task.TargetDate;
            taskToUpdate.UserId = task.UserId;

            await _context.SaveChangesAsync();
            return true ;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
