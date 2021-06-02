using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Application.IdentityUsers.Responses;
using System.Threading.Tasks;

namespace AuthenticationService.Application.IdentityUsers.Interfaces
{
    public interface IIdentityUserAppService
    {
        Task<TokenResponse> LoginAsync(LoginRequest userRequest);
        Task CreateAsync(RegisterRequest userRequest);
        Task ChangePasswordAsync(ChangePasswordRequest userRequest);
        Task LogoutAsync();
    }
}
