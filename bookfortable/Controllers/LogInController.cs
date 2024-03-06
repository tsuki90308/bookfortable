using bookfortable.Models;
using Bookfortable.Models;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_LOGINGED_USER))
            {
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            Member mbr = (new FinalContext().Members.FirstOrDefault(m => m.MAccount.Equals(vm.textAccount) && m.MPassword.Equals(vm.textPassword)));
            if(mbr != null && mbr.MPassword.Equals(vm.textPassword))
            {
                string json = JsonSerializer.Serialize(mbr);
                HttpContext.Session.SetString(CShoppingDictionary.SK_LOGINGED_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
