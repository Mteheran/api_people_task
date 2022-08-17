using Microsoft.AspNetCore.Mvc;

namespace People_Task.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetUsers();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUser(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var result = await _userService.UpdateUser(user);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUser(id);
            return Ok(result);
        }
    }
}