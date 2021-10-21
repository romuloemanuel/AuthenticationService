
using System.Threading.Tasks;

namespace AuthenticationService.Domain.Interfaces.Repositories
{
    public interface IClaimRepository 
    {
        bool UserHasPermissionToPath(string userId, string path);
    }
}
