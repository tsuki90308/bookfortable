﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Blog
{
    public int BlogId { get; set; }

    public int? BtagId { get; set; }

    public string BlogTitle { get; set; }

    public string BlogDescription { get; set; }

    public string Hashtag { get; set; }

    public DateOnly? DateCreated { get; set; }
}