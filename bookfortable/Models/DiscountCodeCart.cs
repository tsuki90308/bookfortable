﻿using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class DiscountCodeCart
{
    public int DiscountId { get; set; }

    public string? DiscountCode { get; set; }

    public string? DiscountType { get; set; }

    public DateTime? DiscountStart { get; set; }

    public DateTime? DiscountEnd { get; set; }

    public int? IsMemberDiscount { get; set; }

    public int? IsPartnerDiscount { get; set; }

    public string? PartnerName { get; set; }

    public string? PartnerManager { get; set; }

    public string? PartnerManagerEmail { get; set; }

    public string? PartnerManagerPhone { get; set; }

    public int? IsActivate { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string? DiscountNote { get; set; }

    public virtual ICollection<MyCoupon> MyCoupons { get; set; } = new List<MyCoupon>();
}
