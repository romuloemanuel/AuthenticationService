using System.Threading.Tasks;

namespace AuthenticationService.Application.Claims.Interfaces
{
    public interface IClaimAppService
    {
        bool UserHasPermissionToPath(string userId, string path);
    }
}
