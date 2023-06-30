namespace DTO
{
    public class LoginResultDTO
    {
        public bool User { get; set; } = false;
        public bool SucessOnSession { get; set; } = false;
        public string? Jwt { get; set; } = null;
    }
}