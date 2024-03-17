using Bookfortable.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bookfortable.Models
{
    public class CTempBoxWrap
    {
        private TempBox _tempbox;
        public TempBox tempbox
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
        [DisplayName("盲盒內容")]
        public string BookTag2string
        {
            get { return _tempbox.BookTag2string; }
            set { _tempbox.BookTag2string = value; }
        }
        [Required(ErrorMessage = "請選擇價格")]
        [DisplayName("價格範圍")]
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
        [DisplayName("手機號碼")]
        public string CustomerPhone
        {
            get { return _tempbox.CustomerPhone; }
            set { _tempbox.CustomerPhone = value; }
        }
        [DisplayName("電子郵件")]
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

        //public virtual Member Member
        //{
        //    get { return _tempbox.Member; }
        //    set { _tempbox.Member = value; }
        //}
        //[Required(ErrorMessage = "請輸入數量")]
        public int txtCount { get; set; }
        public static List<string> chosen { get; set; }

        private static List<string> _booktags;
        public static List<string> booktags
        {
            get { return _booktags ?? (_booktags = new List<string>()); } 
            set { _booktags = value; }
        }
    }
}
