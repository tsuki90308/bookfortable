using Bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
