using Bookfortable.Models;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Bookfortable.Controllers
{
    public class WishListController : Controller
    {
        private IWebHostEnvironment _enviroment = null;
        public WishListController(IWebHostEnvironment p)
        {
            _enviroment = p;
        }
        public IActionResult List(CKeywordViewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<WishList> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.WishLists
                        select p;
            else
                datas = db.WishLists.Where(p => p.ProductName.Contains(vm.txtKeyword) || p.Address.Contains(vm.txtKeyword));

            return View(datas);
        }
        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            WishList prod = db.WishLists.FirstOrDefault(p => p.WishListId == id);
            if (prod == null)
                return RedirectToAction("List");
            CWishListWrap cp = new CWishListWrap();
            cp.wishlist = prod;

            return View(cp);
        }
        [HttpPost]
        public IActionResult Edit(CWishListWrap pIn)
        {
            FinalContext db = new FinalContext();
            WishList pEdit = db.WishLists.FirstOrDefault(p => p.WishListId == pIn.WishListId);
            if (pEdit != null)
            {
                if (pIn.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    pEdit.ProductImage = photoName;
                    pIn.photo.CopyTo(new FileStream(_enviroment.WebRootPath + "../images/" + photoName, FileMode.Create));
                }

                pEdit.ProductName = pIn.ProductName;
                pEdit.ProductDescribe = pIn.ProductDescribe;
                pEdit.WishPrice = pIn.WishPrice;
                pEdit.Address = pIn.Address;
                pEdit.CreationDate = pIn.CreationDate;
                pEdit.Remark = pIn.Remark;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                WishList prod = db.WishLists.FirstOrDefault(p => p.WishListId == id);
                if (prod != null)
                {
                    db.WishLists.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public IActionResult Create(CWishListWrap pIn)
        {
            FinalContext db = new FinalContext();
            if (pIn.photo != null)
            {
                string photoName = Guid.NewGuid().ToString() + ".jpg";
                using (var fileStream = new FileStream(Path.Combine(_enviroment.WebRootPath, "images", photoName), FileMode.Create))
                {
                    pIn.photo.CopyTo(fileStream);
                }
                pIn.ProductImage = photoName;
            }
            db.WishLists.Add(pIn.wishlist);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }

}
