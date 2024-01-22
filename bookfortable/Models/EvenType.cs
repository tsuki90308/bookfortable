using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace bookfortable.Models;

public partial class EvenType
{

    [DisplayName("活動類型編號")]
    public int EvenTypeId { get; set; }


    [DisplayName("活動類型名稱")]
    public string? EvenTypeName { get; set; }

   
    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
