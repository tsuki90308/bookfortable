using Bookfortable.Models;
using System.ComponentModel;

namespace Bookfortable.ViewModels
{
    public class CMemberViewModel
    {
        private readonly Member _member;

        public CMemberViewModel()
        {
            _member = new Member();
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
    }
}
