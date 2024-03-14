﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public int? EventTypeId { get; set; }

    public string EventAddress { get; set; }

    public int EventhostId { get; set; }

    public string EventDescription { get; set; }

    public string Eventhost { get; set; }

    public string EventType { get; set; }

    public string EventImage { get; set; }

    public virtual EvenType EventTypeNavigation { get; set; }

    public virtual Employee EventhostNavigation { get; set; }

    public virtual ICollection<SingUp> SingUps { get; set; } = new List<SingUp>();
}