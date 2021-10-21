using AuthenticationService.Application.Claims.Interfaces;
using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Infra.IoC;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;

namespace AuthenticationService.Infra.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private IClaimAppService _userAppService;

        public CustomAuthorizeAttribute()
        {

        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext authorizationFilterContext)
        {
            _userAppService = SimpleInjectorConfigurationExtension.GetContainer().GetInstance<IClaimAppService>();

            var path = authorizationFilterContext.HttpContext
                .Request.Path;


            var teste = authorizationFilterContext.HttpContext
               .Request.Headers[HeaderNames.Authorization].ToString();
               
            var teste2 = teste.Replace("Bearer ", "");



            var teste1 = new JwtSecurityTokenHandler().ReadJwtToken(teste2);

             _userAppService.UserHasPermissionToPath("",path);


            //var policyProvider = authorizationFilterContext.HttpContext
            //    .RequestServices.GetService<IAuthorizationPolicyProvider>();
            //var policy = await policyProvider.GetPolicyAsync("Teste");
            //var requirement = (ClaimsAuthorizationRequirement)policy.Requirements
            //    .First(r => r.GetType() == typeof(ClaimsAuthorizationRequirement));

            //if (authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    if (!authorizationFilterContext.HttpContext
            //      .User.HasClaim(x => x.Value == requirement.ClaimType))
            //    {
            //        authorizationFilterContext.Result =
            //           new ObjectResult(HttpStatusCode.Unauthorized);
            //    }
            //}
        }
    }
}
