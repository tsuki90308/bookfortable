using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class BookTag
{
    public int BtagId { get; set; }

    public string BtagName { get; set; } = null!;

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();
}
