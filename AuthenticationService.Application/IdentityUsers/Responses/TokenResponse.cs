using System;

namespace AuthenticationService.Application.IdentityUsers.Responses
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
