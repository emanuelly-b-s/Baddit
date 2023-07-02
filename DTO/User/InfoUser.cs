namespace DTO;

public class InfoUser {
    public int UserId { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public  int? PhotoUser { get; set; }
   
}