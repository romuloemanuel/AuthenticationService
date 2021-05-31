using AuthenticationService.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace AuthenticationService.Domain.Interfaces.Services
{
    public interface IIdentityUserService
    {
        Task<TokenModel> LoginAsync(IdentityUser userRequest);
        Task CreateAsync(IdentityUser userRequest);
        Task ChangePasswordAsync(IdentityUser userRequest, string newPassword);
        Task LogoutAsync();
    }
}
