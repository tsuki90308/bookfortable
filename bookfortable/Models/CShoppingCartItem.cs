using bookfortable.Models;
using System.ComponentModel;

namespace Bookfortable.Models
{
    public class CShoppingCartItem
    {
        public int productId { get; set; }
        public string productType { get; set; }
        [DisplayName("數量")]
        public int count { get; set; }
        [DisplayName("單價")]
        public decimal price { get; set; }
        public decimal 小計 { get; set; }
        //public decimal 小計 { get { return this.count * this.price; } }
        public TempBox product { get; set; }
    }
}
