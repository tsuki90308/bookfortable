﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace bookfortable.Models;

public partial class BookTag
{
    [DisplayName("書籤ID")]
    public int BtagId { get; set; }
    [DisplayName("書籤名稱")]

    public string BtagName { get; set; } = null!;

    public virtual ICollection<Relation> Relations { get; set; } = new List<Relation>();
}
