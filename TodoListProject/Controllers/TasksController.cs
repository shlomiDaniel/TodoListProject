using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoListProject.Data;
using TodoListProject.Models;
using TodoListProject.Services;

namespace TodoListProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksService _tasksService;
        private readonly Log _logger;
        public TasksController(TasksService tasksService, Log logger)
        {
            _tasksService = tasksService;
            _logger= logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            var tasks = await _tasksService.GetTasksAsync();

            //register user name to logger
            SignUserNameToLoggerFromHeaders();

            //check if task empty
            if (tasks == null || tasks.Count == 0)
            {
                return NotFound("No tasks found.");
            }

            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask([FromBody] TaskModel task)
        {
            //check if task is null
            if (task == null)
            {
                return BadRequest("Invalid task data.");
            }
            
            var addedTask = await _tasksService.AddTaskAsync(task);
            
            if (addedTask == null)
            {
                return BadRequest("Unable to add the task.");
            }

            SignUserNameToLoggerFromHeaders();
            return Ok(await GetAllTasks());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _tasksService.GetTaskAsync(id);

            if (task == null)
            {
                return NotFound($"Task with ID {id} not found.");
            }

            return Ok(task);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<bool> UpdateTask(int id, TaskModel task)
        {
            if (id != task.Id)
            {
                this._logger.LogError($"Task ID mismatch. Task ID: {id}, Task ID in body: {task.Id}");
                return false;
            }
            else
            {
                var updatedTask = await _tasksService.UpdateTaskAsync(id, task);
                if (!updatedTask)
                {
                    this._logger.LogError("Unable to update the task.");

                    return false;
                }
            }

            SignUserNameToLoggerFromHeaders();
            return true;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<bool> DeleteTask(int id)
        {
           

            bool deletionResult = await _tasksService.DeleteTaskAsync(id);
            if (deletionResult == false)
            {
                this._logger.LogError($"Task with ID {id} not found.");
                return false;
            }
            this._logger.LogError($"Task with ID {id} deleted successfuly.");
            return true;
        }

        [HttpGet("SignUserNameToLoggerFromHeaders")]
        public void SignUserNameToLoggerFromHeaders()
        {
            //sign user name to logger from headers
            var userName = HttpContext.Request.Headers["userName"];

            if (userName.Count == 0)
            {
                this._logger.LogError("User name not found in header.");
            }
            else
            {
                this._logger.LogInformation($"User {userName} requested all tasks.");
            }
        }
    }
}
