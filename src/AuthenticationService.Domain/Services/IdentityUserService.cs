using AuthenticationService.Domain.Interfaces.Services;
using AuthenticationService.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace AuthenticationService.Domain.Services
{
    public class IdentityUserService : IIdentityUserService
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityUserService(SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<TokenModel> LoginAsync(IdentityUser userRequest)
        {
            var user = await _userManager
                .FindByEmailAsync(userRequest.Email);

            if (user == null)
                throw new Exception("Usuário ou senha inválido");

            var userIdentity = await _signInManager.PasswordSignInAsync(user, userRequest.PasswordHash, false, false);

            if (!userIdentity.Succeeded)
                throw new Exception("Usuário ou senha inválido");

            return new TokenModel().GenerateToken(user, _configuration);
        }

        public async Task CreateAsync(IdentityUser userRequest)
        {
            var user = await _userManager
                  .FindByEmailAsync(userRequest.Email);

            if (user != null)
                throw new Exception("Usuário já cadastrado");

            var userIdentity = await _userManager.CreateAsync(userRequest, userRequest.PasswordHash);

            if (!userIdentity.Succeeded)
                throw new Exception("Erro ao criar usuário");
        }

        public async Task ChangePasswordAsync(IdentityUser userRequest, string newPassword)
        {
            var user = await _userManager
                  .FindByLoginAsync(userRequest.Email, userRequest.PasswordHash);

            if (user != null)
                throw new Exception("Usuário ou senha inválido(s)");

            user.PasswordHash = newPassword;

            var userIdentity = await _userManager.UpdateAsync(user);

            if (!userIdentity.Succeeded)
                throw new Exception("Erro ao atualizar a senha");
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
