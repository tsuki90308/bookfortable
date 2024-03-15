using bookfortable.Models;
using Bookfortable.Models;
using Bookfortable.Models.CLoginDictionary;
using Bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Bookfortable.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            //if (HttpContext.Session.Keys.Contains(CShoppingDictionary.SK_LOGINGED_USER))
            //{
            //   //已登入可以訪問
            //    return View();
            //}
            //return RedirectToAction("Login");//未登入返回登入//但不需要qq

            return View();
        }

        public IActionResult Login()
        {
            TempData["Referer"] = Request.Headers["Referer"].ToString();
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
                HttpContext.Session.SetString(CLoginDictionary.SK_LOGINGED_USER, json);

                // 获取前一页面的 URL
                string refererUrl = TempData["Referer"].ToString();
                // 在这里可以根据具体情况进行重定向
                return Redirect(refererUrl);
                //return RedirectToAction("Index");
            }
            return View();
        }

        //回傳json
        //[HttpPost]
        //public IActionResult getLogin(CLoginViewModel vm)
        //{
        //    string json = HttpContext.Session.GetString()
        //}

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CLoginDictionary.SK_LOGINGED_USER);
            string refererUrl = TempData["Referer"].ToString();// 获取前一页面的 URL
            if (refererUrl != null)
                return Redirect(refererUrl);// 在这里可以根据具体情况进行重定向
            else return RedirectToAction("Index");
        }

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
        public IActionResult addMember(CMemberWrap p) {
            Member mp = p.member;
            FinalContext db = new FinalContext();
            db.Members.Add(mp);
            db.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
