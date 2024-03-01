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
    }
}
