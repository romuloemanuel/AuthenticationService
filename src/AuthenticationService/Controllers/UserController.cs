using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Application.IdentityUsers.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="userRequest"></param>
        /// <returns></returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>         
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterAsync(RegisterRequest userRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _identityUserService.CreateAsync(userRequest);

            return Ok();
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        /// <response code="200">Returns a object with token and expiration date</response>
        /// <response code="400">If the item is null</response>      
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(TokenResponse),StatusCodes.Status200OK)]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            TokenResponse loginResponse = await _identityUserService.LoginAsync(loginRequest);

            return Ok(loginResponse);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns nothing</response>
        /// <response code="400">If the item is null</response>      
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _identityUserService.LogoutAsync();

            return Ok();
        }
    }
}
