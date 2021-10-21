using AuthenticationService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthenticationService.Infra.Data.Context
{
    public class AuthenticationContext : IdentityDbContext
    {
        readonly IConfiguration _configuration;

        public AuthenticationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("AccountServiceConnectionString");

            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("AuthenticationService.Infra.Data"));
        }
    }
}
