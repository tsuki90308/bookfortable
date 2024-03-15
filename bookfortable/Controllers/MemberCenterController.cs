using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookfortable.Controllers
{
    public class MemberCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Events()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.SingUps select p;
            return View(datas);
        }

        public IActionResult WishList()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.WishLists select p;
            return View(datas);
        }
        public IActionResult Orders()
        {
            FinalContext db = new FinalContext();
            var datas = from p in db.OrderLists select p;
            return View(datas);
        }
    }
}
