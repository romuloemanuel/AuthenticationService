using AuthenticationService.Domain.Interfaces.Repositories;
using AuthenticationService.Infra.Data.Repositories;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class RepositoryDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IClaimRepository, ClaimRepository>(Lifestyle.Scoped);

        }
    }
}
