﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace bookfortable.Models;

public partial class Result
{
    public int ResultId { get; set; }

    public string ResultMsg { get; set; }

    public string ResultImg { get; set; }

    public string ResultName { get; set; }

    public string ResultTag { get; set; }

    public virtual ICollection<QuestionRecord> QuestionRecords { get; set; } = new List<QuestionRecord>();
}