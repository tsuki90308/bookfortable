﻿using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class SingUp
{
    public int SignUpId { get; set; }

    public int? MemberId { get; set; }

    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Member? Member { get; set; }
}
