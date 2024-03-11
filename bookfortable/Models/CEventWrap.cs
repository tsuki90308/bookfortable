using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace bookfortable.Models
{
    public class CEventWrap
    {
        private Event _Events;
        public Event Events
        {
            get
            {
                return _Events;
            }
            set
            {
                _Events = value;
            }
        }
        public SingUp SingUps
        {
            get
            {
                return _SingUps;
            }
            set
            {
                _SingUps = value;
            }
        }


        private SingUp _SingUps;
        public List<EvenType>? EventTypes { get; set; }
        public List<SelectListItem>? EventTypeOptions { get; set; }

        public List<SelectListItem>? EventAddressTypeOptions { get; set; }

        public List<SelectListItem>? EventhostOptions { get; set; }

        public List<SelectListItem>? signUpIdTypeOptions {  get; set; }

        public Member member { get; set; }

        public CEventWrap()
        {
            _Events = new Event();
            _SingUps = new SingUp();
        }

        public int EventId
        {
            get { return _Events.EventId; }
            set { _Events.EventId = value; }

        }
        [DisplayName("活動名稱")]
        public string? EventName
        {
            get { return _Events.EventName; }
            set { _Events.EventName = value; }

        }

        [DisplayName("活動時間")]
        public DateTime? EventDate
        {
            get { return _Events.EventDate; }
            set { _Events.EventDate = value; }
        }


        public int? EventTypeId
        {
            get { return _Events.EventTypeId; }
            set { _Events.EventTypeId = value; }
        }

        [DisplayName("活動地址")]
        public string? EventAddress
        {
            get { return _Events.EventAddress; }
            set { _Events.EventAddress = value; }
        }


        public int EventhostId
        {
            get { return _Events.EventhostId; }
            set { _Events.EventhostId = value; }
        }


        [DisplayName("活動圖示")]

        public IFormFile photo { get; set; }

        public int SignUpId
        {
            get { return _SingUps.SignUpId; }
            set { _SingUps.SignUpId = value; }
        }
    
        public int? MemberId
        {
            get { return _SingUps.MemberId; }
            set { _SingUps.MemberId = value; }
        }


        public int? S_EventId
        {
            get { return _SingUps.EventId; }
            set { _SingUps.EventId = value; }
        }

        public string? S_EventName
        {
            get { return _SingUps.EventName; }
            set { _SingUps.EventName = value; }
        }
    

        public DateTime? S_EventDate
        {
            get { return _SingUps.EventDate; }
            set { _SingUps.EventDate = value; }
        }

        public string? S_EventAddress
        {
            get { return _SingUps.EventAddress; }
            set { _SingUps.EventAddress = value; }
        }

        public string Eventhost
        {
            get { return _SingUps.Eventhost; }
            set { _SingUps.Eventhost = value; }
        }

        public string EventType
        {
            get { return _SingUps.EventType; }
            set { _SingUps.EventType = value; }
        }

    }
}
