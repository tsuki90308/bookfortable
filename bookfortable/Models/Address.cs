using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int ARegioncode { get; set; }

    public string AAddress { get; set; } = null!;

    public int MemberId { get; set; }

    public virtual Member Member { get; set; } = null!;
}
