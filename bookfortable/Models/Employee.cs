using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EName { get; set; } = null!;

    public string EPassword { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
