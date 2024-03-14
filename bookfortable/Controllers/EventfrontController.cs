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

        //public IActionResult EmailTest()
        //{
        //    using (MimeMessage message = new MimeMessage())
        //    {
        //        //從哪裡寄的
        //        message.From.Add(new MailboxAddress("書服", "bookfortable@gmail.com")); ////改
        //        //寄給誰
        //        message.To.Add(new MailboxAddress("游雅怡", "tayloryo26@gmail.com")); ////改
        //        //主旨
        //        message.Subject = "報名成功通知";

        //        //準備內容
        //        BodyBuilder builder = new BodyBuilder();
        //        builder.HtmlBody = "<h2>活動名稱</h2><ul><li>活動日期:2024/3/29</li><li>活動時間：09:00-12:00</li><li>地址:高雄市...</li></ul>";


        //        //內容(Text、Html)
        //        message.Body = builder.ToMessageBody();


        //        //mail寄送
        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Connect("smtp.gmail.com", 587,SecureSocketOptions.StartTls);//465
        //             smtp.Authenticate("bookfortable@gmail.com", "djjy iyzj fqsb inrn"); //bookfortable6@
        //            smtp.Send(message);
        //            smtp.Disconnect(true);
        //        }
        //    }
        //    return Ok();
        //}
    }
}
