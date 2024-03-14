using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Question()
        {
            ViewBag.score = 0;
            FinalContext db = new FinalContext();
            return View(db.Questions);
        }

        //public IActionResult Result(int score)
        //{
        //    FinalContext db = new FinalContext();
        //    if (score >= 16 && score <= 30)
        //    {
        //        return View(db.Results.Find(1));
        //    }
        //    else if (score >= 11 && score <= 15)
        //    {
        //        return View(db.Results.Find(2));
        //    }
        //    else if (score >= 5 && score <= 10)
        //    {
        //        return View(db.Results.Find(3));
        //    }


        //    return View(db.Results.Find(4));
        //}


    }
}
