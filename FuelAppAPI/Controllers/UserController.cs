using FuelAppAPI.models;
using FuelAppAPI.services;
using Microsoft.AspNetCore.Mvc;

namespace FuelAppAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserServices _userService;

        public UserController(UserServices userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] User user)
        {
            var result = await _userService.createAsync(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _userService.GetAsync();
        }

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Get([FromBody] User user)
        {
            var logedUser = await _userService.LoginAsync(user.email , user.password);

            if (user is null)
            {
                return NotFound();
            }

            return logedUser;
        }
    }
}
