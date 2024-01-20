using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class EvenType
{
    public int EvenTypeId { get; set; }

    public string? EvenTypeName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
