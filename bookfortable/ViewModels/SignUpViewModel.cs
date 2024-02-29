using bookfortable.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace bookfortable.ViewModels
{
    public class SignUpViewModel
    {
      
            // 其他属性
            public int EventTypeId { get; set; }


            public List<SelectListItem>? EventTypeOptions { get; set; }
            public SingUp? SingUp { get; set; }
            public string? S_EventName { get; set; }
            public string? S_EventDate { get; set; }
            public string? S_EventAddress { get; set; }
            public string? Eventhost { get; set; }
            public List<SelectListItem>? EventType { get; set; }
        }
    }
    




 

