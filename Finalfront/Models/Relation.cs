﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortablefront.Models;

public partial class Relation
{
    public int SortId { get; set; }

    public int ProductId { get; set; }

    public int? BookTagId { get; set; }

    public virtual BookTag BookTag { get; set; }

    public virtual Product Product { get; set; }
}