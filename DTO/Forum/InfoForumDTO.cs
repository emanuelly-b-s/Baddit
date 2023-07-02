namespace DTO;

public class InfoForum
{
    public int ID { get; set; }
    public int? Creator { get; set; }
    public string ForumName { get; set; } = null!;
    public string DescriptionForum { get; set; } = null!;

}
