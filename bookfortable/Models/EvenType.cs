﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortable.Models;

public partial class EvenType
{
    public int EvenTypeId { get; set; }

    public string EvenTypeName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}