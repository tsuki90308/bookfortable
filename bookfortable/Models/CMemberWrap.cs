using bookfortable.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookfortable.Models
{
    public class CMemberWrap
    {
        #region
        //[Display(Name ="會員流水號")]
        //public object MemberId;
        //[Display(Name = "帳號")]
        //public object MAccount;
        //[Display(Name = "密碼")]
        //public object MPassword;
        //[Display(Name = "姓名")]
        //public object MName;
        //[Display(Name = "email")]
        //public object MMail;
        //[Display(Name = "大頭貼")]
        //public object MFilepic;
        //[Display(Name = "載具")]
        //public object MCarrier;
        //[Display(Name = "紅利點")]
        //public object? MPoints;
        #endregion
        #region
        private Member _member;
        public Member member
        {
            get { return _member; }
            set { _member = value; }
        }

        public CMemberWrap()
        {
            _member = new Member();
        }
        public CMemberWrap(Member member)
        {
            _member = member;
        }

        [DisplayName("會員流水號")]
        public int MemberId
        {
            get { return _member.MemberId; }
            set { _member.MemberId = value; }
        }
        [DisplayName("帳號")]
        public string MAccount
        {
            get { return _member.MAccount; }
            set { _member.MAccount = value; }
        }
        [DisplayName("密碼")]
        public string MPassword
        {
            get { return _member.MPassword; }
            set { _member.MPassword = value; }
        }
        [DisplayName("姓名")]
        public string MName
        {
            get { return _member.MName; }
            set { _member.MName = value; }
        }
        [DisplayName("email")]
        public string MMail
        {
            get { return _member.MMail; }
            set { _member.MMail = value; }
        }
        [DisplayName("大頭貼")]
        public string MFilepic
        {
            get { return _member.MFilepic; }
            set { _member.MFilepic = value; }
        }
        [DisplayName("載具")]
        public string MCarrier
        {
            get { return _member.MCarrier; }
            set { _member.MCarrier = value; }
        }
        [DisplayName("紅利點")]
        public int? MPoints
        {
            get { return (int?)_member.MPoints; }
            set { _member.MPoints = value; }
        }
        #endregion
    }
}
