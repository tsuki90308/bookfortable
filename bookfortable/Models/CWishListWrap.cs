using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bookfortable.Models
{
    public class CWishListWrap
    {
        private WishList _wishlist;
        public WishList wishlist
        {
            get
            {
                return _wishlist;
            }
            set { _wishlist = value; }
        }
        public CWishListWrap()
        {
            _wishlist = new WishList();
        }
        public int WishListId
        {
            get { return _wishlist.WishListId; }
            set { _wishlist.WishListId = value; }
        }
        [DisplayName("產品名稱")]
        public string? ProductName
        {
            get { return _wishlist.ProductName; }
            set { _wishlist.ProductName = value; }
        }
        [DisplayName("產品圖片")]
        public string? ProductImage
        {
            get { return _wishlist.ProductImage; }
            set { _wishlist.ProductImage = value; }
        }

        public int? ProductId
        {
            get { return _wishlist.ProductId; }
            set { _wishlist.ProductId = value; }
        }
        [DisplayName("產品描述")]
        public string? ProductDescribe
        {
            get { return _wishlist.ProductDescribe; }
            set { _wishlist.ProductDescribe = value; }
        }
        [DisplayName("期望價格")]
        public decimal? WishPrice
        {
            get { return _wishlist.WishPrice; }
            set { _wishlist.WishPrice = value; }
        }
        [DisplayName("地址")]
        public string? Address
        {
            get { return _wishlist.Address; }
            set { _wishlist.Address = value; }
        }

        public int? MemberId
        {
            get { return _wishlist.MemberId; }
            set { _wishlist.MemberId = value; }
        }
        [DisplayName("建立日期")]
        public DateTime? CreationDate
        {
            get { return _wishlist.CreationDate; }
            set { _wishlist.CreationDate = value; }
        }
        [DisplayName("備註")]
        public string? Remark
        {
            get { return _wishlist.Remark; }
            set { _wishlist.Remark = value; }
        }

        public virtual Member? Member
        {
            get { return _wishlist.Member; }
            set { _wishlist.Member = value; }
        }

        public virtual Product? Product
        {
            get { return _wishlist.Product; }
            set { _wishlist.Product = value; }
        }
        public IFormFile photo { get; set; }
    }
}
