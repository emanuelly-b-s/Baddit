using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTO;
public class InfoPostDTO
{
    public string Tittle { get; set; }
    public string PostText { get; set; }
    public DateTime PostDate { get; set; }
    public int Forum { get; set; }
    public int Participant { get; set; }
}
