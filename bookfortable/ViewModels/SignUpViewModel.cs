using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bookfortable.ViewModels
{
    public class SignUpViewModel
    {
        public int SignUpId { get; set; }

        public int? MemberId { get; set; }

        public int? EventId { get; set; }

        public string EventName { get; set; }

        public DateTime? EventDate { get; set; }

        public string EventAddress { get; set; }

        public string EventType { get; set; }

        // 其他属性
        public int EventTypeId { get; set; }
        public string MemberName { get; set; }
        public List<SelectListItem>? EventTypeOptions { get; set; }
        public SingUp? SingUp { get; set; }
        public string? S_EventName { get; set; }
        public string? S_EventDate { get; set; }
        public string? S_EventAddress { get; set; }
        public string? Eventhost { get; set; }
        //public List<SelectListItem>? EventType { get; set; }
    }
}







