using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace AuthenticationService.Infra.IoC
{
    public static class SimpleInjectorConfigurationExtension
    {
        static Container _container = new Container();

        public static void AddSimpleInjectorConfiguration(this IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSimpleInjector(_container, options =>
            {
                options
                .AddAspNetCore()
                .AddControllerActivation();

            });

            services.UseSimpleInjectorAspNetRequestScoping(_container);

            _container.RegisterDependencies();
        }

        public static Container GetContainer(this IApplicationBuilder app) => _container;
        public static Container GetContainer() => _container;

        public static void UseSimpleInjectorConfig(this IApplicationBuilder app)
        {
            app.UseSimpleInjector(_container);
        }
    }
}
