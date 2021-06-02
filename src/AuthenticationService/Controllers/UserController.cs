using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IIdentityUserAppService _identityUserService;
        public UserController(IIdentityUserAppService identityUserService)
        {
            _identityUserService = identityUserService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _identityUserService.CreateAsync(userRequest);

            return Ok();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var loginResponse = await _identityUserService.LoginAsync(loginRequest);

            return Ok(loginResponse);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _identityUserService.LogoutAsync();

            return Ok();
        }
    }
}
