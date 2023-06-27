namespace DTO;

public class NewUserDTO
{
    public string Email { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime DateBirth { get; set; }

    public string NickUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    // public string SaldPassword { get; set; } = null!;

    // public int? PhotoUser { get; set; }
}
