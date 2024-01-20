using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Relation
{
    public int SortId { get; set; }

    public int ProductId { get; set; }

    public int BookTagId { get; set; }

    public virtual BookTag BookTag { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
