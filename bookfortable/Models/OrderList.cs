﻿using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class OrderList
{
    public int Oid { get; set; }

    public string? Oidramd { get; set; }

    public int? OrderDetailId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? IsMember { get; set; }

    public int? MemberId { get; set; }

    public DateTime? PayDate { get; set; }

    public int? IsPayed { get; set; }

    public decimal? OrderTotal { get; set; }

    public string? ShippingTimeReq { get; set; }

    public string? OrderState { get; set; }

    public string? ShippingMethod { get; set; }

    public int? Is711Pay { get; set; }

    public string? Store711 { get; set; }

    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public string? CustomerEmail { get; set; }

    public string? CustomerAdd1 { get; set; }

    public string? CustomerAdd2 { get; set; }

    public string? CustomerAdd3 { get; set; }

    public string? ShippingName { get; set; }

    public string? ShippingPhone { get; set; }

    public string? ShippingAdd1 { get; set; }

    public string? ShippingAdd2 { get; set; }

    public string? ShippingAdd3 { get; set; }

    public string? Phinvoice { get; set; }

    public string? Cpinvoice { get; set; }

    public string? Cptitle { get; set; }

    public string? PayMethod { get; set; }

    public string? DiscountCode { get; set; }

    public decimal? DiscountPrice { get; set; }

    public decimal? ShippingFeed { get; set; }

    public int? Points { get; set; }

    public string? OrderListNote { get; set; }

    public virtual Member? Member { get; set; }

    public virtual OrderDetail? OrderDetail { get; set; }
}
