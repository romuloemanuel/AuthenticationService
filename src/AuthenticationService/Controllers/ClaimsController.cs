
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AuthenticationService.Controllers
{
    [ApiController]
    [Route("api/claim")]
    public class ClaimsController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ClaimsController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpPost]
        [Route("role")]
        [AllowAnonymous]
        public async Task<IActionResult> AddByRoleAsync(string roleName, ClaimPost claim)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            Claim claimToAdd = new Claim(claim.Type, claim.Value);

            var result = await roleManager.AddClaimAsync(role, claimToAdd);

            return Ok(result);
        }

        //[HttpPost]
        //[Route("user")]
        //[AllowAnonymous]
        //public async Task<IActionResult> AddByUserAsync(ClaimPost claim)
        //{
        //    Claim claimToAdd = new Claim(claim.Type, claim.Value);

       

        //    var result = await _userManager.Add(claimToAdd);

        //    return Ok(result);
        //}

        [HttpPost]
        [Route("user")]
        [AllowAnonymous]
        public async Task<IActionResult> AddByUserAsync(string roleName, ClaimPost claim)
        {
            Claim claimToAdd = new Claim(claim.Type, claim.Value);

            var user = await _userManager
                  .FindByNameAsync(roleName);

            var result = await _userManager.AddClaimAsync(user, claimToAdd);

            return Ok(result);
        }
    }

    public class ClaimPost
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
