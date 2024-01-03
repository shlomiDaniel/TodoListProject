using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListProject.Models;
using TodoListProject.Services;

namespace TodoListProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly UsersService _usersService;
        private readonly Log _logger;

        public UsersController(UsersService usersService, Log logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _usersService.GetAllUsers();
            if (users == null || users.Count == 0)
            {
                var errorMessage = "No users found.";
                _logger.LogError(errorMessage);
                return NotFound(errorMessage);
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _usersService.GetUserById(id);

                return user != null
                    ? Ok(user)
                    : NotFound("No users found.");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                    return BadRequest("Invalid user data.");

                if (user.Id == 0)
                    return BadRequest("User ID must be bigger than 0.");

                var userId = await _usersService.InsertUser(user);
                return Ok(userId);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateUser([FromBody] User user)
        {
            try
            {
                if (user == null)
                {
                    var errorMessage = "Invalid user data.";
                    _logger.LogError(errorMessage);
                    return BadRequest(errorMessage);
                }

                var result = await _usersService.UpdateUser(user);
                return Ok(result);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController.UpdateUser: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            try
            {
                
                var result = await _usersService.DeleteUser(id);
                if (!result)
                {
                    var errorMessage = $"User with ID {id} not found.";
                    _logger.LogError(errorMessage);
                    return NotFound(errorMessage);
                }
                    

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController.DeleteUser: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpPost]
        [Route("AddTaskToUser")]
        public async Task<ActionResult<bool>> AddTaskToUser([FromBody] TaskModel task, int userId)
        {
            try
            {
                if (task == null)
                {
                    var errorMessage = "Invalid task data.";
                    _logger.LogError(errorMessage);
                    return BadRequest(errorMessage);
                }

                var result = await _usersService.AddTaskToUser(userId, task);

                if (result)
                {
                    return Ok(true);
                }
                else
                {
                    _logger.LogError($"User with ID {userId} not found.");
                    return NotFound($"User with ID {userId} not found.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UserController.AddTaskToUser: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
