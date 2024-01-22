using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace bookfortable.Models;


public partial class Event
{
    [DisplayName("活動編號")]
    public int EventId { get; set; }

    [DisplayName("活動名稱")]
    public string? EventName { get; set; }

    [DisplayName("活動時間")]
    public DateTime? EventDate { get; set; }

    [DisplayName("活動類型編號")]
    public int? EventTypeId { get; set; }

    [DisplayName("活動地址")]
    public string? EventAddress { get; set; }

    [DisplayName("主辦人編號")]
    public int EventhostId { get; set; }

    [DisplayName("活動類型")]
    public virtual EvenType? EventType { get; set; }

    [DisplayName("主辦人")]
    public virtual Employee Eventhost { get; set; } = null!;

    [DisplayName("報名")]
    public virtual ICollection<SingUp> SingUps { get; set; } = new List<SingUp>();
}
