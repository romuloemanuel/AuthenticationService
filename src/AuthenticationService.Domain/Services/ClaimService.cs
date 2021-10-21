using AuthenticationService.Domain.Interfaces.Repositories;
using AuthenticationService.Domain.Interfaces.Services;
using System;

namespace AuthenticationService.Domain.Services
{
    public   class ClaimService: IClaimService
    {
        private IClaimRepository _claimRepository;
        public ClaimService(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository; 
        }

        bool IClaimService.UserHasPermissionToPath(string userId, string path)
        {
            return _claimRepository.UserHasPermissionToPath(userId,path);
        }
    }
}
