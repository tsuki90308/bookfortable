using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class TradeList
{
    public int TradeListId { get; set; }

    public int? ProductId { get; set; }

    public string? ProductDescribe { get; set; }

    public string? Address { get; set; }

    public int? MemberId { get; set; }

    public string? State { get; set; }

    public string? Remark { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Product? Product { get; set; }
}
