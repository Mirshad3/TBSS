using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] int? customerId, [FromQuery] int? projectId)
        {
            // Implement logic to get users with optional filters
            var users = _userService.GetUsers(customerId, projectId);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User userDto)
        {
            // Implement logic to add a new user
            var createdUser = _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User userDto)
        {
            // Implement logic to update an existing user
            var updatedUser = _userService.UpdateUser(userDto);
            if (updatedUser == null)
                return NotFound();

            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            // Implement logic to delete a user
            var deleted = _userService.DeleteUser(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
