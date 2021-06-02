using AuthenticationService.Domain.Interfaces.Services;
using AuthenticationService.Domain.Services;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class DomainDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IIdentityUserService, IdentityUserService>(Lifestyle.Scoped);
        }
    }
}
