using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO;

public class NewPostDTO
{
    public required string Tittle { get; set; }
    public required string PostText { get; set; }
    public DateTime PostDate { get; set; }
    public int Forum { get; set; }
    public int Participant { get; set; }


}
