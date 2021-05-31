using AuthenticationService.Infra.IoC.Modules;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC
{
    public static class DependencyInjectionBootStrapper
    {
        public static void RegisterDependencies(this Container container)
        {
            ServicesDependencyModule.Register(container);
            DomainDependencyModule.Register(container);
            RepositoryDependencyModule.Register(container);
            DbContextDependencyModule.Register(container);
            AutoMapperDependencyModule.Register(container);
        }
    }
}
