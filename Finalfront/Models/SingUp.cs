﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortablefront.Models;

public partial class SingUp
{
    public int SignUpId { get; set; }

    public int? MemberId { get; set; }

    public int? EventId { get; set; }

    public string EventName { get; set; }

    public DateTime? EventDate { get; set; }

    public string EventAddress { get; set; }

    public string Eventhost { get; set; }

    public string EventType { get; set; }

    public virtual Event Event { get; set; }

    public virtual Member Member { get; set; }
}