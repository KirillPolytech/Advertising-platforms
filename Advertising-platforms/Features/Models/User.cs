namespace Advertising_platforms.Features.Models
{
    public class User
    {
        public required string Username { get; set; } = string.Empty;
        public required string Password { get; set; } = string.Empty;
        public required string Role { get; set; } = string.Empty;
    }
}