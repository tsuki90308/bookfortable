using Bookfortable.Models;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Linq;

namespace Bookfortable.Controllers
{
    public class RelationController : Controller
    {

        public IActionResult List()
        {
            FinalContext db = new FinalContext();
            //var data = from r in db.Relations
            //           join b in db.BookTags on r.BookTagId equals b.BtagId
            //           select new {r.ProductId, b.BtagId, b.BtagName};
            //List<string> tags = data.GroupBy(r => r.ProductId).SelectMany(group => group.Select(r => r.BtagName))
            //            .ToList();
            var datas = from r in db.Relations
                        join p in db.Products on r.ProductId equals p.ProductId
                        join b in db.BookTags on r.BookTagId equals b.BtagId
                        select new CRelationViewModel()
                        {
                            relation = r,
                            product = p,
                            booktag = b,
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
                var productId = db.Relations.Where(r => r.SortId == id).Select(r => r.ProductId).FirstOrDefault();
                List<Relation> pRemove = db.Relations.Where(r => r.ProductId == productId).ToList();

                db.Relations.RemoveRange(pRemove);
                db.SaveChanges();
            }
            return RedirectToAction("List");

        }
        public IActionResult Edit(int? id, string tagNameString)
        {
            FinalContext db = new FinalContext();
            Relation relation = db.Relations.FirstOrDefault(p => p.SortId == id);
            if (relation != null)
            {
                var productList = db.Products.ToList();
                var bookTagList = db.BookTags.ToList();
                CRelationViewModel data = new CRelationViewModel()
                {
                    relation = relation,
                    bookTagNameList = bookTagList.Select(p => p.BtagName).ToList(),
                    productName = productList.FirstOrDefault(p => p.ProductId == relation.ProductId).ProductName,
                    bookTagName = bookTagList.FirstOrDefault(p => p.BtagId == relation.BookTagId).BtagName,
                    tagNameString = tagNameString
                };
                return View(data);
            }
            return RedirectToAction("List");
        }
        //        [HttpPost]
        //        public IActionResult Edit(CRelationViewModel pIn)
        //        {
        //            FinalContext db = new FinalContext();
        //            List<Relation> pEdit = db.Relations.Where(r => r.ProductId == pIn.relation.ProductId).ToList();
        //            List<int> nowTag = pEdit.Select(p => p.BookTagId).ToList();//NOTAG 現在所有的TAG的ID
        //            List<int> AddTagList = db.BookTags.Where(p => pIn.tagNameString.Contains(p.BtagName)).Select(p => p.BtagId).ToList(); //欲新增的tag id
        //            if (pEdit != null)
        //            {
        //                var sameTag = AddTagList.Intersect(nowTag).ToList();
        //                for (int i = 0; i < sameTag.Count; i++)
        //                {
        //                    nowTag.Remove(sameTag[i]);
        //                    AddTagList.Remove(sameTag[i]);

        //                }
        //                pEdit.Clear();
        //                for (int i = 0; i < AddTagList.Count; i++)
        //                {
        //                    pEdit.Add(new Relation
        //                    {
        //                        ProductId = pIn.relation.ProductId,
        //                        BookTagId = AddTagList[i]
        //                    });
        //                }

        //                db.Relations.AddRange(pEdit);

        //                for (int i = 0; i < nowTag.Count; i++)
        //                {
        //                    Relation pRemove = db.Relations.Where(r => r.ProductId == pIn.relation.ProductId && r.BookTagId == nowTag[i]).FirstOrDefault();
        //                    db.Remove(pRemove);
        //                }

        //                db.SaveChanges();
        //            }
        //            return RedirectToAction("List");
        //        }
    }
}