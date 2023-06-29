namespace DTO
{
    public class LoginResultDTO
    {
        public bool UserExists { get; set; } = false;
        public bool Success { get; set; } = false;
        public string? Jwt { get; set; } = null;
    }
}