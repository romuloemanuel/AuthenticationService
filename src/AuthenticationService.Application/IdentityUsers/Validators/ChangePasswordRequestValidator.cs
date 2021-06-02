using AuthenticationService.Application.IdentityUsers.Requests;
using FluentValidation;

namespace AuthenticationService.Application.IdentityUsers.Validators
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {

        }
    }
}
