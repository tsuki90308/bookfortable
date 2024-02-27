using System.ComponentModel;

namespace bookfortable.Models
{
    public class DiscountCodeCartWrap
    {
        private DiscountCodeCart _discountcodecart;

        public DiscountCodeCart discountcodecart
        {
            get { return _discountcodecart; }
            set { _discountcodecart = value; }
        }

        public DiscountCodeCartWrap()
        {
            _discountcodecart = new DiscountCodeCart();
        }

        public int DiscountId
        {
            get { return _discountcodecart.DiscountId; }
            set { _discountcodecart.DiscountId = value; }
        }
        [DisplayName("折扣代碼")]
        public string? DiscountCode
        {
            get { return _discountcodecart.DiscountCode; }
            set { _discountcodecart.DiscountCode = value; }
        }
        [DisplayName("類型")]
        public string? DiscountType
        {
            get { return _discountcodecart.DiscountType; }
            set { _discountcodecart.DiscountType = value; }
        }
        [DisplayName("起迄時間")]
        public DateTime? DiscountStart
        {
            get { return _discountcodecart.DiscountStart; }
            set { _discountcodecart.DiscountStart = value; }
        }
        [DisplayName("結束時間")]
        public DateTime? DiscountEnd
        {
            get { return _discountcodecart.DiscountEnd; }
            set { _discountcodecart.DiscountEnd = value; }
        }
        [DisplayName("會員專屬")]
        public bool? IsMemberDiscount
        {
            get { return _discountcodecart.IsMemberDiscount; }
            set { _discountcodecart.IsMemberDiscount = value; }
        }
        [DisplayName("業配")]
        public bool? IsPartnerDiscount
        {
            get { return _discountcodecart.IsPartnerDiscount; }
            set { _discountcodecart.IsPartnerDiscount = value; }
        }
        [DisplayName("合作夥伴")]
        public string? PartnerName
        {
            get { return _discountcodecart.PartnerName; }
            set { _discountcodecart.PartnerName = value; }
        }
        [DisplayName("聯絡人")]
        public string? PartnerManager
        {
            get { return _discountcodecart.PartnerManager; }
            set { _discountcodecart.PartnerManager = value; }
        }
        [DisplayName("聯絡人電郵")]
        public string? PartnerManagerEmail
        {
            get { return _discountcodecart.PartnerManagerEmail; }
            set { _discountcodecart.PartnerManagerEmail = value; }
        }
        [DisplayName("聯絡人電話")]
        public string? PartnerManagerPhone
        {
            get { return _discountcodecart.PartnerManagerPhone; }
            set { _discountcodecart.PartnerManagerPhone = value; }
        }
        [DisplayName("狀態")]
        public bool? IsActivate
        {
            get { return _discountcodecart.IsActivate; }
            set { _discountcodecart.IsActivate = value; }
        }
        [DisplayName("折扣價格")]
        public decimal? DiscountPrice
        {
            get { return _discountcodecart.DiscountPrice; }
            set { _discountcodecart.DiscountPrice = value; }
        }
        [DisplayName("備註")]
        public string? DiscountNote
        {
            get { return _discountcodecart.DiscountNote; }
            set { _discountcodecart.DiscountNote = value; }
        }
    }
}
