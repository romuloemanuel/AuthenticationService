using AuthenticationService.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;
using AutoMapper;
using AuthenticationService.Application.Claims.Interfaces;

namespace AuthenticationService.Application.Claims.Services
{
    public class ClaimAppService : IClaimAppService
    {
        private IClaimService _claimService;
        private IMapper _mapper;
        public ClaimAppService( IMapper mapper, IClaimService claimService)
        {
            _mapper = mapper;
            _claimService = claimService;
        }

     

        bool IClaimAppService.UserHasPermissionToPath(string userId, string path)
        {
            return _claimService.UserHasPermissionToPath(userId, path);
        }
    }
}
