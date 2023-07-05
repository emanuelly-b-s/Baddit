using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO;
public class InfoPostDTO
{
    public int Id { get; set; }
    public string Tittle { get; set; }
    public string PostText { get; set; }
    public DateTime PostDate { get; set; }
    public int Forum { get; set; }
    public int Participant { get; set; }
    public int Upvote { get; set; }
    public int Downvote { get; set; }
}
