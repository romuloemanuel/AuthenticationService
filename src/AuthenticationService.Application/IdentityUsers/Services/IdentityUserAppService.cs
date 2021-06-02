using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Application.IdentityUsers.Responses;
using AuthenticationService.Domain.Interfaces.Services;
using System.Threading.Tasks;
using AuthenticationService.Application.IdentityUsers.Validators;
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationService.Application.IdentityUsers.Services
{
    public class IdentityUserAppService : IIdentityUserAppService
    {
        private IIdentityUserService _identityUserService;
        private IMapper _mapper;
        public IdentityUserAppService(IIdentityUserService identityUserService, IMapper mapper)
        {
            _identityUserService = identityUserService;
            _mapper = mapper;
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest chancePasswordRequest )
        {
            var validator = new ChangePasswordRequestValidator().Validate(chancePasswordRequest);
            
            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(chancePasswordRequest);

            await _identityUserService.ChangePasswordAsync(identityUser,chancePasswordRequest.NewPassword);
        }

        public async Task CreateAsync(RegisterRequest registerRequest)
        {
            var validator = new RegisterRequestValidator().Validate(registerRequest);

            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(registerRequest);

            await _identityUserService.CreateAsync(identityUser);
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            var validator = new LoginRequestValidator().Validate(loginRequest);

            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(loginRequest);

            var tokenModel = await _identityUserService.LoginAsync(identityUser);

            return _mapper.Map<TokenResponse>(tokenModel);
        }

        public async Task LogoutAsync()
        {
           await  _identityUserService.LogoutAsync();
        }
    }
}
