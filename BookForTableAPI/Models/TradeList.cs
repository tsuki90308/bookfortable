﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace BookForTableAPI.Models;

public partial class TradeList
{
    public int TradeListId { get; set; }

    public string ProductName { get; set; }

    public string ProductImage { get; set; }

    public int? ProductId { get; set; }

    public string ProductDescribe { get; set; }

    public string Address { get; set; }

    public int? MemberId { get; set; }

    public string State { get; set; }

    public string Remark { get; set; }

    public virtual Member Member { get; set; }

    public virtual Product Product { get; set; }
}