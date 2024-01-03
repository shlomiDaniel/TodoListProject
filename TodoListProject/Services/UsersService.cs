using Microsoft.EntityFrameworkCore;
using TodoListProject.Models;
using Microsoft.AspNetCore.Mvc;
using TodoListProject.Data;


namespace TodoListProject.Services
{
    public class UsersService
    {
        private readonly DataContext _context;

        public UsersService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        public async Task<int> InsertUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var userToUpdate = await _context.Users.FindAsync(user.Id);
            if (userToUpdate == null)
            {
                return false;
            }

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Tasks = user.Tasks;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
        
        //add task to user 
        public async Task<bool> AddTaskToUser(int userId, int taskId)
        {
            var user = await _context.Users.FindAsync(userId);
            var task = await _context.Tasks.FindAsync(taskId);
            if (user == null || task == null)
                return false;
            user.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> AddTaskToUser(int userId, TaskModel task)
        {
            try
            {
                // Fetch the user from the database
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return false;
                }

                // Add the task to the user's collection
                user.Tasks.Add(task);

                // Save changes to the database
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw;
            }
        }
    

}
}
