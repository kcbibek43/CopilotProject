using Microsoft.AspNetCore.Mvc;
using YourNamespace.Models;
using YourNamespace.Services;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UsersService _usersService;

        public AuthController(UsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(User user)
        {
            var existingUser = _usersService.GetByEmail(user.Email);
            if (existingUser != null)
            {
                return BadRequest("User already exists with this email.");
            }

            user = _usersService.Create(user);

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserLogin userLogin)
        {
            var user = _usersService.GetByEmailAndPassword(userLogin.Email, userLogin.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            
            return user;
        }

        [HttpPost("usernames")]
        public ActionResult<IEnumerable<string>> GetUsernamesByIds([FromBody] string[] ids)
        {
            var usernames = ids.Select(id => _usersService.GetById(id)?.UserName).Where(username => username != null).ToArray();

            if (usernames.Length == 0)
            {
                return NotFound();
            }

            return Ok(usernames);
        }
    }
}
