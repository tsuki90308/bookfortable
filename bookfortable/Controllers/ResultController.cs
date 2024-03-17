using Bookfortable.Models;
using Bookfortable.ViewModels;
using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.Controllers
{
    public class ResultController : Controller
    {
        private IWebHostEnvironment _enviro = null;
        public ResultController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        public IActionResult List(BKeywordViewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<Result> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.Results
                        select p;
            else
                datas = db.Results.Where(p => p.ResultName.Contains(vm.txtKeyword) ||
                p.ResultMsg.Contains(vm.txtKeyword) ||
                p.ResultTag.Contains(vm.txtKeyword));
            //p.FPhone.Contains(vm.txtKeyword) ||
            //p.FEmail.Contains(vm.txtKeyword) ||
            //p.FAddress.Contains(vm.txtKeyword));
            return View(datas);

        }


        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Result prod = db.Results.FirstOrDefault(p => p.ResultId == id);
            if (prod == null)
                return RedirectToAction("List");
            CResultWrap cp = new CResultWrap();
            cp.result = prod;
            return View(cp);
        }
        [HttpPost]
        public IActionResult Edit(CResultWrap pIn)
        {
            FinalContext db = new FinalContext();
            Result pEdit = db.Results.FirstOrDefault(p => p.ResultId == pIn.ResultId);
            if (pEdit != null)
            {
                if (pIn.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    pEdit.ResultImg = photoName;
                    pIn.photo.CopyTo(new FileStream(Path.Combine(_enviro.WebRootPath, "img", photoName), FileMode.Create));
                }
                pEdit.ResultName = pIn.ResultName;
                pEdit.ResultMsg = pIn.ResultMsg;
                pEdit.ResultTag = pIn.ResultTag;
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
                Result book = db.Results.FirstOrDefault(p => p.ResultId == id);
                if (book != null)
                {
                    db.Results.Remove(book);
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
        public IActionResult Create(CResultWrap p)
        {
            FinalContext db = new FinalContext();
            if (p.photo != null)
            {
                string photoName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                p.ResultImg = photoName;

                using (FileStream fs = new FileStream(Path.Combine(_enviro.WebRootPath, "img", photoName), FileMode.Create))
                {
                    p.photo.CopyTo(fs);
                }
                p.result.ResultImg = photoName;
            }


            db.Results.Add(p.result);
            db.SaveChanges();
            return RedirectToAction("List");

        }
    }
}