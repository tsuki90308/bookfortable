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
            FinalContext db = new FinalContext();
            return View(db.Questions);
        }



    }
}
