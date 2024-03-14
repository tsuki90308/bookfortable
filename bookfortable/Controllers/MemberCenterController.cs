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
            return View();
        }

        public IActionResult WishList()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        }
    }
}
