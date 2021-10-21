using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;

namespace AuthenticationService.Infra.Data.Repositories
{
    public class ClaimRepository : IClaimRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public ClaimRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public bool UserHasPermissionToPath(string userId, string path)
        {
            var has = _unitOfWork.Context.Set<IdentityRoleClaim<Guid>>().Any(c => c.ClaimValue == path);

            return has;
        }
    }
}
