using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? SupplierId { get; set; }

    public string? ProductPhoto { get; set; }

    public string? Description { get; set; }

    public decimal? UnitPrice { get; set; }

    public int? UnitsInStock { get; set; }

    public string? VersionInfo { get; set; }

    public DateOnly? PublicationDate { get; set; }

    public decimal? SellingPrice { get; set; }

    public string? Isbn { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();

    public virtual ICollection<TradeList> TradeLists { get; set; } = new List<TradeList>();

    public virtual ICollection<WishList> WishLists { get; set; } = new List<WishList>();
}
