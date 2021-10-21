using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Application.IdentityUsers.Responses;
using AuthenticationService.Domain.Interfaces.Services;
using System.Threading.Tasks;
using System;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using FluentValidation;

namespace AuthenticationService.Application.IdentityUsers.Services
{
    public class IdentityUserAppService : IIdentityUserAppService
    {
        readonly IIdentityUserService _identityUserService;
        readonly IMapper _mapper;
        readonly IValidator<ChangePasswordRequest> _changePassworRequestValidator;
        readonly IValidator<RegisterRequest> _registerRequestValidator;
        readonly IValidator<LoginRequest> _loginRequestValidator;
        public IdentityUserAppService(
            IIdentityUserService identityUserService, IMapper mapper,
            IValidator<ChangePasswordRequest> changePassworRequestValidator,
            IValidator<RegisterRequest> registerRequestValidator,
            IValidator<LoginRequest> loginRequestValidator)
        {
            _identityUserService = identityUserService;
            _mapper = mapper;
            _changePassworRequestValidator = changePassworRequestValidator;
            _registerRequestValidator = registerRequestValidator;
            _loginRequestValidator = loginRequestValidator;
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest chancePasswordRequest)
        {
            var validator = _changePassworRequestValidator.Validate(chancePasswordRequest);

            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(chancePasswordRequest);

            await _identityUserService.ChangePasswordAsync(identityUser, chancePasswordRequest.NewPassword);
        }

        public async Task CreateAsync(RegisterRequest registerRequest)
        {
            var validator = _registerRequestValidator.Validate(registerRequest);

            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(registerRequest);

            await _identityUserService.CreateAsync(identityUser);
        }

        public async Task<TokenResponse> LoginAsync(LoginRequest loginRequest)
        {
            var validator = _loginRequestValidator.Validate(loginRequest);

            if (!validator.IsValid)
                throw new Exception(validator.Errors.FirstOrDefault().ErrorMessage);

            var identityUser = _mapper.Map<IdentityUser>(loginRequest);

            var tokenModel = await _identityUserService.LoginAsync(identityUser);

            return _mapper.Map<TokenResponse>(tokenModel);
        }

        public async Task LogoutAsync()
        {
            await _identityUserService.LogoutAsync();
        }
    }
}
