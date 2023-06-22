using System;
using System.Collections.Generic;

namespace Back.Model;

public partial class ImageDatum
{
    public int Id { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual ICollection<LocationPhoto> LocationPhotos { get; set; } = new List<LocationPhoto>();
}
