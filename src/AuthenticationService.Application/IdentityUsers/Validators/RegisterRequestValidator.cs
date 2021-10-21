using AuthenticationService.Application.IdentityUsers.Requests;
using FluentValidation;

namespace AuthenticationService.Application.IdentityUsers.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
        }
    }
}
