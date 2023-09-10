using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TBSS.Model;
using TBSS.Repositories.IRepositories;

namespace TBSS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authService;

        public AuthController(IAuthRepository authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] User loginRequest)
        {
            // Implement authentication logic (JWT generation)
            var token = _authService.Authenticate(loginRequest.Username, loginRequest.PasswordHash);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }

        [HttpPost("Logout")]
        [Authorize] // Requires a valid token
        public IActionResult Logout()
        {
            // Implement logout logic (if needed)
            return Ok("Logged out successfully");
        }
        
    }
}
