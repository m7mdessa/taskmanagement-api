using Application.Auth;
using Application.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]

    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegistrationRequest request)
        {
            bool usernameExists = _authService.IsUsernameTaken(request?.UserName);
            bool emailExists = _authService.IsEmailTaken(request.Email);

            if (usernameExists)
            {
                return Conflict(new { error = "username already exists" });
            }
            else if (emailExists)
            {
                return Conflict(new { error = "email already exists" });
            }

            _authService.Register(request);

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("Login")]

        public IActionResult Login([FromBody] AuthRequest request)
        {
            var token = _authService.Login(request);


            return Ok(token);

        }

    

        [HttpGet("checkUsername/{username}")]
        public IActionResult IsUsernameTaken(string username)
        {
            
            if (_authService.IsUsernameTaken(username))
            {
                return BadRequest("Username is already taken.");
            }

            return Ok(true); 
        }

        [HttpGet("checkEmail/{email}")]
        public IActionResult IsEmailTaken(string email)
        {


            if (_authService.IsEmailTaken(email))
            {
                return BadRequest("Email is already taken.");
            }

            return Ok(true);
        }
    }
}
