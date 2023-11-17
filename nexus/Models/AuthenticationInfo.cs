namespace nexus.Models
{
    // Authentication Model
    public class AuthenticationInfo
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        // Other authentication-related properties and methods...
    }


}
