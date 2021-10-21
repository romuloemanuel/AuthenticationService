using AuthenticationService.Application.IdentityUsers.Requests;
using AuthenticationService.Application.IdentityUsers.Validators;
using FluentValidation;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class ValidatorsDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IValidator<ChangePasswordRequest>, ChangePasswordRequestValidator>(Lifestyle.Scoped);
            container.Register<IValidator<LoginRequest>, LoginRequestValidator>(Lifestyle.Scoped);
            container.Register<IValidator<RegisterRequest>, RegisterRequestValidator>(Lifestyle.Scoped);
        }
    }
}
