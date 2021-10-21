namespace AuthenticationService.Application.IdentityUsers.Requests
{
    public class LoginRequest
    {
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
    }
}
