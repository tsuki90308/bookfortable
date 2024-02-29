using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookfortable.Controllers
{
    public class EventfrontController : Controller
    {
        private FinalContext db = new FinalContext();
        public IActionResult Index()
        {
            List<Event> events = db.Events.ToList(); // 從資料庫中取得所有事件
            return View(events);
        }
        // 其他操作如新增、編輯、刪除事件的Action方法可以根據需要添
    }
}
