using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class OrderDetail
{
    public int Odid { get; set; }

    public string? OrderDetailId { get; set; }

    public int? ProductId { get; set; }

    public int? ProductAmount { get; set; }

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();

    public virtual Product? Product { get; set; }
}
