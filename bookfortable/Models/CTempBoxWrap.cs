using bookfortable.Models;

namespace Bookfortable.Models
{
    public class CTempBoxWrap
    {
        private TempBox _tempbox;
        public TempBox TempBox
        {
            get { return _tempbox; }
            set { _tempbox = value; }
        }
        public CTempBoxWrap()
        {
            _tempbox = new TempBox();
        }
        public int BoxId
        {
            get { return _tempbox.BoxId; }
            set { _tempbox.BoxId = value; }
        }

        public string BookTag2string
        {
            get { return _tempbox.BookTag2string; }
            set { _tempbox.BookTag2string = value; }
        }

        public decimal? PriceRange
        {
            get { return _tempbox.PriceRange; }
            set { _tempbox.PriceRange = value; }
        }

        public int? MemberId
        {
            get { return _tempbox.MemberId; }
            set { _tempbox.MemberId = value; }
        }

        public string CustomerPhone
        {
            get { return _tempbox.CustomerPhone; }
            set { _tempbox.CustomerPhone = value; }
        }

        public string CustomerEmail
        {
            get { return _tempbox.CustomerEmail; }
            set { _tempbox.CustomerEmail = value; }
        }

        public DateTime? BuildDate
        {
            get { return _tempbox.BuildDate; }
            set { _tempbox.BuildDate = value; }
        }

        public virtual Member Member
        {
            get { return _tempbox.Member; }
            set { _tempbox.Member = value; }
        }
    }
}
