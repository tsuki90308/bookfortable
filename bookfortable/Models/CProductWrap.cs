using System.ComponentModel.DataAnnotations;

namespace bookfortable.Models
{
    public class CProductWrap
    {
        private Product _product;
        public Product product
        {
            get
            {
                return _product;
            }
            set { _product = value; }
        }
        public CProductWrap()
        {
            _product = new Product();
        }
        public int ProductId
        {
            get
            {
                return _product.ProductId;
            }
            set { _product.ProductId = value; }
        }
        [Display(Name = "書籍名稱")]
        public string? ProductName
        {
            get
            {
                return _product.ProductName;
            }
            set { _product.ProductName = value; }
        }

        [Display(Name = "出版社")]
        public string? SupplierId
        {
            get
            {
                return _product.SupplierId;
            }
            set { _product.SupplierId = value; }
        }
        [Display(Name = "封面照片")]
        public string? ProductPhoto
        {
            get
            {
                return _product.ProductPhoto;
            }
            set { _product.ProductPhoto = value; }
        }
        [Display(Name = "書籍介紹")]
        public string? Description
        {
            get
            {
                return _product.Description;
            }
            set { _product.Description = value; }
        }

        [Display(Name = "單價")]
        public decimal? UnitPrice
        {
            get
            {
                return _product.UnitPrice;
            }
            set { _product.UnitPrice = value; }
        }

        [Display(Name = "庫存量")]
        public int? UnitsInStock
        {
            get
            {
                return _product.UnitsInStock;
            }
            set { _product.UnitsInStock = value; }
        }
        [Display(Name = "版本資訊")]
        public string? VersionInfo
        {
            get
            {
                return _product.VersionInfo;
            }
            set { _product.VersionInfo = value; }
        }
        [Display(Name = "出版日期")]
        public DateOnly? PublicationDate
        {
            get
            {
                return _product.PublicationDate;
            }
            set { _product.PublicationDate = value; }
        }
        [Display(Name = "售價")]
        public decimal? SellingPrice
        {
            get
            {
                return _product.SellingPrice;
            }
            set { _product.SellingPrice = value; }
        }
        [Display(Name = "國際索書號")]
        public string? Isbn
        {
            get
            {
                return _product.Isbn;
            }
            set { _product.Isbn = value; }
        }

        public IFormFile photo { get; set; }
    }
}
