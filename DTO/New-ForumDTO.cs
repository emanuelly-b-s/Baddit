    namespace DTO;

public class NewForumDTO
{
    public required InfoUser Owner { get; set; }
    public string ForumName { get; set; } = null!;
    public string DescriptionForum { get; set; } = null!;

}
