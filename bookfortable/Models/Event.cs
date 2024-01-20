using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string? EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public int? EventTypeId { get; set; }

    public string? EventAddress { get; set; }

    public int EventhostId { get; set; }

    public virtual EvenType? EventType { get; set; }

    public virtual Employee Eventhost { get; set; } = null!;

    public virtual ICollection<SingUp> SingUps { get; set; } = new List<SingUp>();
}
