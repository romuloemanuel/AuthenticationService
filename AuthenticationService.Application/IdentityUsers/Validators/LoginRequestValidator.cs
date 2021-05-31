using AuthenticationService.Application.IdentityUsers.Requests;
using FluentValidation;

namespace AuthenticationService.Application.IdentityUsers.Validators
{
    public class LoginRequestValidator: AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {

        }
    }
}
