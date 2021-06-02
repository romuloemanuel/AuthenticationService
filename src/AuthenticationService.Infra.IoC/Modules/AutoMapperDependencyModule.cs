using AuthenticationService.Application.IdentityUsers.Mappers;
using AutoMapper;
using SimpleInjector;

namespace AuthenticationService.Infra.IoC.Modules
{
    public class AutoMapperDependencyModule
    {
        public static void Register(Container container)
        {
            var mapping = CreateMapping();

            container.RegisterInstance(mapping);
        }

        private static IMapper CreateMapping()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new IdentityUserModelResponseProfile());
                mc.AddProfile(new IdentityUserRequestEntityProfile());
            });

            return mappingConfig.CreateMapper();
        }
    }
}
