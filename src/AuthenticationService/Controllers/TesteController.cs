using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [Authorize]
    [Route("api/teste1")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        public TesteController()
        {

        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            return Ok(DateTime.UtcNow);
        }
    }
}
