using Bookfortable.Models;
using Bookfortable.Models.CLoginDictionary;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class MemberCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Orders(int? id)
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.OrderLists where p.MemberId == id select p;
            return View(datas);
        }
        public IActionResult WishList(int? id)
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.WishLists where p.MemberId == id select p;
            return View(datas);
        }
        public IActionResult Events(int? id)
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.SingUps where p.MemberId == id select p;
            return View(datas);
        }
        public IActionResult FrontEidt(int? id)
        {
            FinalContext db = new FinalContext();
            Member mbr = db.Members.FirstOrDefault(p => p.MemberId == id);
            if (id != null)
            {
                if (mbr == null)
                {
                    return RedirectToAction("Index");
                }
            }
            CMemberWrap wrap = new CMemberWrap(mbr);
            return View(wrap);
        }

        [HttpPost]
        public IActionResult FrontEidt(CMemberWrap mIn, IFormFile File)
        {
            FinalContext db = new FinalContext();
            Member mEdit = db.Members.FirstOrDefault(p => p.MemberId == mIn.MemberId);
            if (mEdit != null)
            {
                if(mIn.MAccount != null)
                    mEdit.MAccount = mIn.MAccount;
                if (mIn.MPassword != null)
                    mEdit.MPassword = mIn.MPassword;
                if (mIn.MName != null)
                    mEdit.MName = mIn.MName;
                if (mIn.MMail != null)
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

                string json = JsonSerializer.Serialize(mEdit);
                HttpContext.Session.SetString(CLoginDictionary.SK_LOGINGED_USER, json);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("FrontEidt", mIn.MemberId);
        }
    }
}
