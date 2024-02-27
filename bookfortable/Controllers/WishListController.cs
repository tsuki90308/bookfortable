using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace bookfortable.Controllers
{
    public class WishListController : Controller
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<WishList> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.WishLists
                        select p;
            else
                datas = db.WishLists.Where(p => p.ProductName.Contains(vm.txtKeyword));

            return View(datas);
        }
        public ActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            WishList prod = db.WishLists.FirstOrDefault(p => p.WishListId == id);
            if (prod == null)
                return RedirectToAction("List");
            

            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(WishList pIn)
        {
            FinalContext db = new FinalContext();
            WishList pEdit = db.WishLists.FirstOrDefault(p => p.WishListId == pIn.WishListId);
            if (pEdit != null)
            {
                //if (pIn.photo != null)
                //{
                //    string photoName = Guid.NewGuid().ToString() + ".jpg";
                //    pEdit.ProductImage = photoName;
                //    pIn.photo.CopyTo(new FileStream(_enviroment.WebRootPath + "/images/" + photoName, FileMode.Create));
                //}


                pEdit.WishPrice = pIn.WishPrice;
                pEdit.ProductDescribe = pIn.ProductDescribe;
                pEdit.Address = pIn.Address;
                pEdit.Remark = pIn.Remark;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(WishList p)
        {
            FinalContext db = new FinalContext();
            db.WishLists.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
