﻿using bookfortable.Models;
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
            return View();
        }
        [HttpPost]
        public IActionResult Login(CLoginViewModel vm)
        {
            Member mbr = (new FinalContext().Members.FirstOrDefault(m => m.MAccount.Equals(vm.textAccount) && m.MPassword.Equals(vm.textPassword)));
            if(mbr != null && mbr.MPassword.Equals(vm.textPassword))
            {
                string json = JsonSerializer.Serialize(mbr);
                HttpContext.Session.SetString(CLoginDictionary.SK_LOGINGED_USER, json);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CLoginDictionary.SK_LOGINGED_USER);
            string action = HttpContext.Session.GetString(CLoginDictionary.SK_PREVIUS_ACTION);
            string controller = HttpContext.Session.GetString(CLoginDictionary.SK_PREVIUS_CONTROLLER);
            if(action != null && controller != null)
                return RedirectToAction(action, controller);
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
    }
}
