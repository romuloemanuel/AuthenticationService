
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return Ok("teste");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRole(string  name )
        {
            if (ModelState.IsValid)
            {
                // precisamos apenas especificar o nome único da role
                IdentityRole identityRole = new IdentityRole
                {
                    Name = name
                };
                // Salva a role na tabela AspNetRole
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {

                }
                //foreach (IdentityError error in result.Errors)
                //{
                //}
            }
            return Ok();
        }
    }
}
