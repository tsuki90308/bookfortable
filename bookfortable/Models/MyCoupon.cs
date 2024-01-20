using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class MyCoupon
{
    public int McId { get; set; }

    public int DicountId { get; set; }

    public int MemberId { get; set; }

    public virtual DiscountCodeCart Dicount { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;
}
