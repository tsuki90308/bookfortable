using Bookfortable.Models;
using Bookfortable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Bookfortable.ViewModels;

namespace Bookfortable.Controllers
{
    public class ShoppingController : Controller
    {


        //虛擬商場, 之後連接組長負責的部分
        public IActionResult List()
        {
            FinalContext db = new FinalContext();
            var datas = from t in db.TempBoxes select t;
            List<CTempBoxWrap> list = new List<CTempBoxWrap>();
            foreach (TempBox t in datas)
            {
                list.Add(new CTempBoxWrap() { tempbox = t });
            }
            return View(list);
        }
        public IActionResult GenerateBox()
        {
            FinalContext db = new FinalContext();
            var datas = from b in db.BookTags select b;
            CTempBoxWrap.booktags = new List<string>();
            foreach (var t in datas)
            {
                CTempBoxWrap.booktags.Add(t.BtagName.ToString());
            }
            return View();
        }

        [HttpPost]
        public IActionResult GenerateBox(CTempBoxWrap t)
        {
            List<string> list = CTempBoxWrap.chosen;
            string str = string.Empty;//tag2string
            foreach (string s in list)
            {
                int now = list.IndexOf(s);
                int last = list.Count - 1;

                str += s;
                if (now != last)
                    str += ",";
            }
            t.BookTag2string = str;

            string json = "";
            List<CShoppingCartItem> cart = new List<CShoppingCartItem>();
            if (HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
            {
                json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
                cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            }
            CShoppingCartItem item = new CShoppingCartItem();
            item.price = (decimal)t.PriceRange;
            item.productType = t.BookTag2string;
            item.count = t.txtCount;
            cart.Add(item);
            json = JsonSerializer.Serialize(cart);
            HttpContext.Session.SetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST, json);

            return RedirectToAction("GenerateBox");
            //if (ModelState.IsValid)
            //{
            //    List<string> list = CTempBoxWrap.chosen;
            //    string str = string.Empty;//tag2string
            //    foreach(string s in list)
            //    {
            //        int now = list.IndexOf(s);
            //        int last = list.Count - 1;

            //        str += s;
            //        if (now != last)
            //            str += ",";
            //    }
            //    t.BookTag2string = str;

            //    string json = "";
            //    List<CShoppingCartItem> cart = new List<CShoppingCartItem>();
            //    if (HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
            //    {
            //        json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            //        cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            //    }
            //    CShoppingCartItem item = new CShoppingCartItem();
            //    item.price = (decimal)t.PriceRange;
            //    item.productType = t.BookTag2string;
            //    item.count = t.txtCount;
            //    cart.Add(item);
            //    json = JsonSerializer.Serialize(cart);
            //    HttpContext.Session.SetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST, json);

            //    return RedirectToAction("GenerateBox");
            //}
            //else
            //{
            //    return View(t);
            //}
        }
        //已選擇的tag的list
        [HttpPost]
        public IActionResult TagList(List<string> chosenTags)
        {
            CTempBoxWrap.chosen = chosenTags;
            return Json(new { success = true });
        }

        public IActionResult AddToCart(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            ViewBag.BoxId = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel vm)
        {
            FinalContext db = new FinalContext();
            TempBox pDb = db.TempBoxes.FirstOrDefault(t => t.BoxId == vm.txtBoxId);
            if (pDb != null)
            {
                string json = "";
                List<CShoppingCartItem> cart = null;
                if (HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
                {
                    json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
                }
                else
                    cart = new List<CShoppingCartItem>();
                CShoppingCartItem item = new CShoppingCartItem();
                item.price = (decimal)pDb.PriceRange;
                item.productType = pDb.BookTag2string;
                item.productId = vm.txtBoxId;
                item.count = vm.txtCount;
                item.product = pDb;
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST, json);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult UpdateCartItem(int boxid, int newCount, decimal newSubtotal)
        {
            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            var cartitem = cart.Find(i => i.productId == boxid);
            if (cartitem != null)
            {
                cartitem.productId = boxid;
                cartitem.count = newCount;
                cartitem.小計 = newSubtotal;
                HttpContext.Session.SetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST, JsonSerializer.Serialize(cart));
            }

            // 可选：返回任何适当的响应
            return Json(new { success = true, message = "Count updated successfully" });
        }


        public IActionResult Createbox()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Createbox(TempBox t)
        {
            FinalContext db = new FinalContext();
            db.TempBoxes.Add(t);
            db.SaveChanges();
            CTempBoxWrap tbw = new CTempBoxWrap();
            tbw.tempbox = t;
            return RedirectToAction("CartView");
        }

        public IActionResult Deletebox(int? id)
        {

            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            var cartitem = cart.Find(i => i.productId == id);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }
            HttpContext.Session.SetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST, JsonSerializer.Serialize(cart));

            FinalContext db = new FinalContext();
            var TempBox = db.TempBoxes.Where(t => t.BoxId == id).FirstOrDefault();
            if (TempBox != null)
            {
                db.TempBoxes.Remove(TempBox);
                db.SaveChanges();
            }
            return RedirectToAction("CartView");
        }

        [HttpPost]
        public IActionResult ApplyDiscount([FromBody] CDiscountCodeViewModel vm)
        {
            bool isValidDiscount = false;
            decimal? discountPrice = 0;
            DiscountCodeCart discountcode = (new FinalContext()).DiscountCodeCarts.FirstOrDefault(d => d.DiscountCode.Equals(vm.txtDiscountCode) && d.IsActivate == true);

            if (discountcode != null && discountcode.DiscountCode.Equals(vm.txtDiscountCode) && discountcode.IsActivate == true)
            {
                isValidDiscount = true;
                discountPrice = discountcode.DiscountPrice;
            }

            return Content(discountPrice.ToString());
        }



        //購物車頁首
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("GenerateBox");

            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            if (cart == null)
                return RedirectToAction("GenerateBox");
            return View(cart);
        }


    }
}
