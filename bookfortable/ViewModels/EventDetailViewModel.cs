using bookfortable.Models;

namespace bookfortable.ViewModels
{
    public class EventDetailViewModel
    {
        public Event Event { get; internal set; }
        public List<SingUp> SingUps { get; internal set; }
    }
}
