﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Bookfortable.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int ARegioncode { get; set; }

    public string AAddress { get; set; }

    public int MemberId { get; set; }

    public virtual Member Member { get; set; }
}