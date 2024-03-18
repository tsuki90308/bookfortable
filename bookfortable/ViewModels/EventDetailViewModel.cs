using Bookfortable.Models;

namespace Bookfortable.ViewModels
{
    public class EventDetailViewModel
    {
        public Event Event { get; internal set; }
        public List<SingUp> SingUps { get; internal set; }
    }
}
