using AuthenticationService.Infra.Data.Context;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class DbContextDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<AuthenticationContext>(Lifestyle.Scoped);
        }
    }
}
