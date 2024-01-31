using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bookfortable.Controllers
{
    public class BookTagController : Controller
    {
        public IActionResult List(BKeywordViewModel vm)
        {
           FinalContext db = new FinalContext();
            IEnumerable<BookTag> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.BookTags
                        select p;
            else
                datas = db.BookTags.Where(p => p.BtagName.Contains(vm.txtKeyword));
                    //p.FPhone.Contains(vm.txtKeyword) ||
                    //p.FEmail.Contains(vm.txtKeyword) ||
                    //p.FAddress.Contains(vm.txtKeyword));
            return View(datas);
        }


        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
           BookTag prod = db.BookTags.FirstOrDefault(p => p.BtagId == id);
            if (prod == null)
                return RedirectToAction("List");

            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(BookTag pIn)
        {
            FinalContext db = new FinalContext();
            BookTag pEdit = db.BookTags.FirstOrDefault(p => p.BtagId == pIn.BtagId);
            if (pEdit != null)
            {
                pEdit.BtagName = pIn.BtagName;
                //pEdit.FPhone = pIn.FName;
           
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                BookTag book = db.BookTags.FirstOrDefault(p => p.BtagId == id);
                if (book != null)
                {
                    db.BookTags.Remove(book);
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
        public IActionResult Create(BookTag p)
        {
            FinalContext db = new FinalContext();
            db.BookTags.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");

        }

    }
}
