using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.Controllers
{
    public class QuestionController : Controller
    {
      
            public IActionResult List(BKeywordViewModel vm)
            {
                FinalContext db = new FinalContext();
                IEnumerable<Question> datas = null;
                if (string.IsNullOrEmpty(vm.txtKeyword))
                    datas = from p in db.Questions
                            select p;
                else
                    datas = db.Questions.Where(p => p.QuestionName.Contains(vm.txtKeyword));
                //p.FPhone.Contains(vm.txtKeyword) ||
                //p.FEmail.Contains(vm.txtKeyword) ||
                //p.FAddress.Contains(vm.txtKeyword));
                return View(datas);

            }
        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Question prod = db.Questions.FirstOrDefault(p => p.QuestionId == id);
            if (prod == null)
                return RedirectToAction("List");

            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Question pIn)
        {
            FinalContext db = new FinalContext();
            Question pEdit = db.Questions.FirstOrDefault(p => p.QuestionId == pIn.QuestionId);
            if (pEdit != null)
            {
                pEdit.QuestionName = pIn.QuestionName;
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
                Question quiz = db.Questions.FirstOrDefault(p => p.QuestionId == id);
                if (quiz != null)
                {
                    db.Questions.Remove(quiz);
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
        public IActionResult Create(Question p)
        {
            FinalContext db = new FinalContext();
            db.Questions.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");

        }


    }
}
