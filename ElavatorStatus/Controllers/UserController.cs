using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Schindler.ElavatorStatus.Domain;

namespace Schindler.ElavatorStatus.WebService.Controllers
{
    [ApiController]
    [Route("v1/api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userService;

        public UserController(IUserRepository userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}