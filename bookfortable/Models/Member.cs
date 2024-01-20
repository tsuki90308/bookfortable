using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Member
{
    public int MemberId { get; set; }

    public string MAccount { get; set; } = null!;

    public string MPassword { get; set; } = null!;

    public string MName { get; set; } = null!;

    public string? MMail { get; set; }

    public string? MFilepic { get; set; }

    public string? MCarrier { get; set; }

    public int? MPoints { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<MyCoupon> MyCoupons { get; set; } = new List<MyCoupon>();

    public virtual ICollection<OrderList> OrderLists { get; set; } = new List<OrderList>();

    public virtual ICollection<SingUp> SingUps { get; set; } = new List<SingUp>();

    public virtual ICollection<TradeList> TradeLists { get; set; } = new List<TradeList>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
