﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortable.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EName { get; set; }

    public string EPassword { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<PickingOrder> PickingOrders { get; set; } = new List<PickingOrder>();
}