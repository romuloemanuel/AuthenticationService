using AuthenticationService.Application.IdentityUsers.Interfaces;
using AuthenticationService.Application.IdentityUsers.Services;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class ServicesDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IIdentityUserAppService, IdentityUserAppService>(Lifestyle.Scoped);
        }
    }
}
