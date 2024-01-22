using Microsoft.AspNetCore.Mvc;

namespace bookfortable.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
