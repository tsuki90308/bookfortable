using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace bookfortable.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult List()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.Members select p;
            return View(datas);
        }

        public IActionResult Delete(int? id)
        {
            FinalContext db = new FinalContext();
            Member mbr = db.Members.FirstOrDefault(p => p.MemberId == id);
            if (id != null)
            {
                if(mbr != null)
                {
                    db.Members.Remove(mbr);
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
        public IActionResult Create(Member p)
        {
            FinalContext db = new FinalContext();
            db.Members.Add(p);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Member mbr = db.Members.FirstOrDefault(p => p.MemberId == id);
            if (id != null)
            {
                if (mbr == null)
                {
                    return RedirectToAction("List");
                }
            }
            return View(mbr);
        }

        [HttpPost]
        public IActionResult Edit(Member mIn)
        {
            FinalContext db = new FinalContext();
            Member mEdit = db.Members.FirstOrDefault(p => p.MemberId == mIn.MemberId);
            if (mEdit != null)
            {
                mEdit.MAccount = mIn.MAccount;
                mEdit.MPassword = mIn.MPassword;
                mEdit.MName = mIn.MName;
                mEdit.MMail = mIn.MMail;
                if(mIn.MFilepic != null)
                    mEdit.MFilepic = mIn.MFilepic;
                if(mIn.MCarrier != null)
                    mEdit.MCarrier = mIn.MCarrier;
                mEdit.MPoints = mIn.MPoints;

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }
    }
}
