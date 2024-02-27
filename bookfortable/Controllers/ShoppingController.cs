using Bookfortable.Models;
using bookfortable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class ShoppingController : Controller
    {
        //虛擬商場, 之後連接組長負責的部分
        public IActionResult List()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.Members select p;
            return View(datas);
        }

        //購物車頁首
        public IActionResult CartView()
        {


            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);

            return View(cart);

        }
    }
}
