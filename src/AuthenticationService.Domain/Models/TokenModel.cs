using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService.Domain.Models
{
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

        public TokenModel FillProperties(string token, DateTime dataExpiration)
        {
            this.Token = token;
            this.Expiration = dataExpiration;
            return this;
        }

        public TokenModel GenerateToken(IdentityUser user, IConfiguration configuration)
        {
            var issuer = configuration["Jwt:Issuer"]; //quem emite o token JWT

            var audience = configuration["Jwt:Audience"];// aplicações que podem usar o token JWT

            var expiry = DateTime.UtcNow.AddSeconds(30);//

            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));

            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);

            var handler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                new Claim("name","Rômulo")
             }), //Claims
                Issuer = issuer,
                Audience = audience,
                IssuedAt = DateTime.UtcNow, //Data/hora que o token foi gerado 
                NotBefore = DateTime.UtcNow,//
                Expires = expiry,
                SigningCredentials = credentials//Credenciais para gerar token.
            });

            var stringToken = handler.WriteToken(securityToken);

            return FillProperties(stringToken, expiry);
        }

    }
}
