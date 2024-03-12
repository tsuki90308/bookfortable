﻿using Bookfortable.Models;
using bookfortable.Models;
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
            string str = string.Empty;
            foreach(string s in list)
            {
                int now = list.IndexOf(s);
                int last = list.Count - 1;

                str += s;
                if (now != last)
                    str += ",";
            }

            TempBox tp = t.tempbox;
            t.BookTag2string = str;
            FinalContext db = new FinalContext();
            db.TempBoxes.Add(tp);
            db.SaveChanges();

            return RedirectToAction("Generate");
        }

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
        public ActionResult UpdateCount(int newCount, decimal newSubtotal)
        {
            CShoppingCartItem item = new CShoppingCartItem
            {
                count = newCount,
                小計 = newSubtotal
            };

            // 在这里更新服务器上的数据，例如：item.count = newCount;

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
            if (id != null)
            {
                FinalContext db = new FinalContext();
                TempBox tb = db.TempBoxes.FirstOrDefault(p => p.BoxId == id);
                if (tb != null)
                {
                    db.TempBoxes.Remove(tb);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("CartView");
        }

        [HttpPost]
        public IActionResult ApplyDiscount([FromBody] CDiscountCodeViewModel vm)
        {
            bool isValidDiscount = false;
            decimal? discountPrice = 0;
            DiscountCodeCart discountcode = (new FinalContext()).DiscountCodeCarts.FirstOrDefault(d => d.DiscountCode.Equals(vm.txtDiscountCode) && d.IsActivate == true);

            //DiscountCodeCart discountcode = (new FinalContext()).DiscountCodeCarts.FirstOrDefault(
            //    d => d.DiscountCode.Equals(vm.txtDiscountCode) &&
            //    //d.IsMemberDiscount.Equals(vm.boolIsMemberDiscount) &&
            //    d.IsActivate.Equals(1)); //&&
            //d.DiscountPrice.Equals(vm.DiscountPrice));

            if (discountcode != null && discountcode.DiscountCode.Equals(vm.txtDiscountCode) && discountcode.IsActivate == true)
            {
                isValidDiscount = true;
                discountPrice = discountcode.DiscountPrice;

            }

            return Content(discountPrice.ToString());
            //  return Json({ });

            //ViewBag.IsValidDiscount = isValidDiscount;
            //string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            //List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            //if (cart == null)
            //    return RedirectToAction("List");
            //return View("CartView", cart);
        }

        //購物車頁首
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("List");


            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            if (cart == null)
                return RedirectToAction("List");
            return View(cart);

        }

        //未成為訂單明細的資料
        public IActionResult checkout()
        {
            FinalContext db = new FinalContext();

            string json = HttpContext.Session.GetString(CShoppingDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);

            return View("CheckOut");
        }
    }
}
