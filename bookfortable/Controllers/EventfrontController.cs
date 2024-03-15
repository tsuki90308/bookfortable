using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

//using System.Net.Mail;

namespace bookfortable.Controllers
{
    public class EventfrontController : Controller
    {
        //private FinalContext db = new FinalContext();
        private readonly FinalContext _db;  //全域變數

        public EventfrontController(FinalContext dbContext)
        {
            _db = dbContext;
        }
        // GET: Eventfront/List
        [HttpGet]
        public IActionResult List()
        {
            var events = _db.Events.ToList();
            return View(events);  // 從資料庫中取得所有事件

        }
        // GET: Eventfront/Create/{id}
        [HttpGet]
        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @event = _db.Events.FirstOrDefault(e => e.EventId == id);

            if (@event == null)
            {
                return NotFound();
            }

            return View(@event);
        }
        // POST: Eventfront/Create
        [HttpPost]
        public IActionResult Create(SingUp model)
        {
            if (ModelState.IsValid)
            {
                // 將報名資料寫入資料庫
                _db.SingUps.Add(model);
                _db.SaveChanges();

                // 報名完成後轉到 SignUp/List Action
                return RedirectToAction("List", "SignUp");
            }

            return View(model); // 如果模型驗證失敗，返回報名頁面，讓使用者重新填寫
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Fans()
        {

            return View();
        }
        public IActionResult Donate()
        {
            return View();
        }

       public IActionResult ContactUs()
        {
            return View();
        }
    }
}
