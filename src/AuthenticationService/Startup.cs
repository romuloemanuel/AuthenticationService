using AuthenticationService.Infra.Data.Context;
using AuthenticationService.Infra.Extensions;
using AuthenticationService.Infra.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AuthenticationService.Infra.Extensions;

namespace AuthenticationService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string _allowOriginPolicy = "AllowOrigin";


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<AuthenticationContext>();


            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<AuthenticationContext>();

            services.AddJwtConfiguration(Configuration);

            services.AddAuthorization();

            services.AddControllers();
            services.AddSimpleInjectorConfiguration();

            services.AddSwaggerConfig();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerConfig();
            }

            app.UseSimpleInjectorConfig();

            app.UseCors(p =>
                {
                    p
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
