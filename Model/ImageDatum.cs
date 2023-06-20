using System;
using System.Collections.Generic;

namespace Model;

public partial class ImageDatum
{
    public int Id { get; set; }

    public byte[] Photo { get; set; } = null!;

    public virtual ICollection<LocationPhoto> LocationPhotos { get; set; } = new List<LocationPhoto>();
}
