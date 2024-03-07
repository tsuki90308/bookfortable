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
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //回傳view版
        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            Member mbr = (new FinalContext().Members.FirstOrDefault(m => m.MAccount.Equals(vm.textAccount) && m.MPassword.Equals(vm.textPassword)));
            if (mbr != null && mbr.MPassword.Equals(vm.textPassword))
            {
                string json = JsonSerializer.Serialize(mbr);
                HttpContext.Session.SetString(CShoppingDictionary.SK_LOGINGED_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }

        //回傳json
        //[HttpPost]
        //public IActionResult getLogin(CLoginViewModel vm)
        //{
        //    string json = HttpContext.Session.GetString()
        //}

        //public IActionResult Test()
        //{
        //    string json = HttpContext.Session.GetString(CShoppingDictionary.SK_LOGINGED_USER);
        //    if (!string.IsNullOrEmpty(json))
        //    {
        //        Member mbr = JsonSerializer.Deserialize<Member>(json);
        //    }
        //}


        public IActionResult addMember()
        {
            return View();
        }

            [HttpPost]
        public IActionResult addMember(Member p) { 
            FinalContext db = new FinalContext();
            db.Members.Add(p);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
