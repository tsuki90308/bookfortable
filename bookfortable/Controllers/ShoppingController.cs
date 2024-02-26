using Bookfortable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class ShoppingController : Controller
    {
        // GET: ShoppingController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ShoppingController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShoppingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShoppingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShoppingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ShoppingController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShoppingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
