using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace Bookfortable.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult List()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.Members select p;
            List<CMemberWrap> list = new List<CMemberWrap>();
            foreach (var data in datas)
            {
                list.Add(new CMemberWrap(data));
            }
            return View(list);
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
            CMemberWrap wrap = new CMemberWrap();
            wrap.member = mbr;
            return View(wrap);
        }

        [HttpPost]
        public IActionResult Edit(CMemberWrap mIn, IFormFile File)
        {
            FinalContext db = new FinalContext();
            Member mEdit = db.Members.FirstOrDefault(p => p.MemberId == mIn.MemberId);
            if (mEdit != null)
            {
                mEdit.MAccount = mIn.MAccount;
                mEdit.MPassword = mIn.MPassword;
                mEdit.MName = mIn.MName;
                mEdit.MMail = mIn.MMail;

                if (File != null)
                {
                    // Convert the uploaded file to a byte array
                    using (MemoryStream ms = new MemoryStream())
                    {
                        File.CopyTo(ms);
                        mEdit.MFilepic = ms.ToArray();
                    }
                }

                if (mIn.MCarrier != null)
                    mEdit.MCarrier = mIn.MCarrier;
                mEdit.MPoints = mIn.MPoints;

                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        //*** 把資料表裡面的「二進位」內容，還原成圖片檔 ****************************
        public FileContentResult GetImage(int? id)
        {
            FinalContext db = new FinalContext();
            Member requestedPfp = db.Members.FirstOrDefault(p => p.MemberId == id);


            if (requestedPfp != null)
            {
                return File(requestedPfp.MFilepic, "image/jpeg");
            }
            else
            {
                return null;
            }
        }

        public IActionResult giveme()
        {
            return View();
        }
    }
}
