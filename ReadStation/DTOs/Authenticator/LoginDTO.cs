namespace ReadStation.DTOs.Authenticator
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
    }
}
