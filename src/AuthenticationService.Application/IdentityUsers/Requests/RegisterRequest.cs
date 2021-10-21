namespace AuthenticationService.Application.IdentityUsers.Requests
{
    public class RegisterRequest
    {
        /// <summary>
        /// Name of the user
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Email of the user
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Password of the user
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// PhoneNumber of the user
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
