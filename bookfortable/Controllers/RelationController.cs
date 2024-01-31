using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace bookfortable.Controllers
{
    public class RelationController : Controller
    {
    
            public IActionResult List()
            {
                FinalContext db = new FinalContext();
            var datas = from r in db.Relations
                        join p in db.Products on r.ProductId equals p.ProductId
                        join b in db.BookTags on r.BookTagId equals b.BtagId
                        select new CRelationViewModel()
                        {
                            relation = r,
                            productName = p.ProductName,
                            bookTagName = b.BtagName
                        };
                return View(datas);
            }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Relation p)
        {
            FinalContext db = new FinalContext();
            db.Relations.Add(p); //這個有問題 有序號列
            db.SaveChanges();
            return RedirectToAction("List");

        }
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                Relation book = db.Relations.FirstOrDefault(p => p.SortId == id);
                if (book != null)
                {
                    db.Relations.Remove(book);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");

        }
        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Relation relation = db.Relations.FirstOrDefault(p=>p.SortId == id);
            if (relation != null)
            {
                var productList = db.Products.ToList();
                var bookTagList = db.BookTags.ToList();
                CRelationViewModel data = new CRelationViewModel()
                {
                    relation = relation,
                    productNameList = productList.Select(p => p.ProductName).ToList(),
                    bookTagNameList = bookTagList.Select(p=>p.BtagName).ToList(),
                    productName = productList.FirstOrDefault(p => p.ProductId == relation.ProductId).ProductName,
                    bookTagName = bookTagList.FirstOrDefault(p => p.BtagId == relation.BookTagId).BtagName,
                };
                return View(data);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public IActionResult Edit(CRelationViewModel pIn)
        {
            FinalContext db = new FinalContext();
            Relation pEdit = db.Relations.FirstOrDefault(p => p.SortId == pIn.relation.SortId);
            if (pEdit != null)
            {
                pEdit.ProductId = db.Products.Where(p => p.ProductName == pIn.productName).Select(p => p.ProductId).FirstOrDefault();
                pEdit.BookTagId = db.BookTags.Where(p => p.BtagName == pIn.bookTagName).Select(p => p.BtagId).FirstOrDefault();

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
