using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookfortable.Models;

public partial class SingUp
{
    [DisplayName("活動註冊編號")]
    [Required]
    public int SignUpId { get; set; }

    [DisplayName("會員編號")]
    [Required]
    public int? MemberId { get; set; }

    [DisplayName("活動編號")]
    [Required]
    public int? EventId { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Member? Member { get; set; }
}
