﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortable.Models;

public partial class TempBox
{
    public int BoxId { get; set; }

    public string BookTag2string { get; set; }

    public decimal? PriceRange { get; set; }

    public int? MemberId { get; set; }

    public string CustomerPhone { get; set; }

    public string CustomerEmail { get; set; }

    public DateTime? BuildDate { get; set; }

    public virtual Member Member { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PickingOrder> PickingOrders { get; set; } = new List<PickingOrder>();
}