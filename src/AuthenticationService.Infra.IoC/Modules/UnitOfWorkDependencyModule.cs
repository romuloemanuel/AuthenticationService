using AuthenticationService.Domain.Interfaces;
using AuthenticationService.Infra.Data;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public static class UnitOfWorkDependencyModule
    {
        public static void Register(Container container)
        {
            container.Register<IUnitOfWorkFactory, UnitOfWorkFactory>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
        }
    }
}
