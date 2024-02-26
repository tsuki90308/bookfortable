using bookfortable.Models;

namespace Bookfortable.Models
{
    public class CShoppingCartItem
    {
        public int productId { get; set; }
        public int count { get; set; }
        public decimal price { get; set; }
        public decimal 小計 { get { return this.count * this.price; } }
        public TempBox product { get; set; }
    }
}
