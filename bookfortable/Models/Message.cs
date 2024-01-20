﻿using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string? Email { get; set; }

    public int? MemberId { get; set; }

    public DateTime? MessageDate { get; set; }

    public string? Message1 { get; set; }

    public virtual Member? Member { get; set; }
}
