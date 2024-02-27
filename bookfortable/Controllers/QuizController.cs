using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            FinalContext db = new FinalContext();
            return View(db.Questions);
        }
    }
}
