using bookfortable.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookfortable.ViewModels
{
    public class SignUpPageViewModel
    {
        // 其他属性
        public List<Event>? Events { get; set; }
        public List<EvenType>? EventTypes { get; set; }
        public List<SelectListItem>? EventTypeOptions { get; set; }
        public SingUp? SingUp { get; set; }
        public List<SingUp>? SingUps { get; set; }

    }

}