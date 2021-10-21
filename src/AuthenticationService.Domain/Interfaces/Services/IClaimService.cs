
namespace AuthenticationService.Domain.Interfaces.Services
{
    public interface IClaimService
    {
        bool UserHasPermissionToPath(string userId, string path);
    }
}
