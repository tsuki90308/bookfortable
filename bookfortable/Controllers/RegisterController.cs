using Microsoft.AspNetCore.Mvc;
using bookfortable.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bookfortable.Controllers
{
    public class RegisterController : Controller
    {

        private readonly FinalContext _context;

        public RegisterController(FinalContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Register(int eventId)
        {
            // 根據 eventId 從數據庫中獲取相應的活動信息
            var @event = _context.Events.FirstOrDefault(e => e.EventId == eventId);

            if (@event == null)
            {
                // 如果找不到相應的活動，返回 NotFound 結果
                return NotFound();
            }

            // 假設其他報名邏輯...

            // 如果所有邏輯成功完成，重定向到報名結果頁面
            return RedirectToAction("RegistrationResult", new { eventId = eventId });
        }

        public IActionResult RegistrationResult(int eventId)
        {
            // 根據 eventId 從數據庫中獲取相應的活動信息
            var @event = _context.Events.FirstOrDefault(e => e.EventId == eventId);

            if (@event == null)
            {
                // 如果找不到相應的活動，返回 NotFound 結果
                return NotFound();
            }
            SingUp singUp = new SingUp()//寫入到SQL
            {
                MemberId = 2,
                EventId = @event.EventId,
                EventName = @event.EventName,
                EventDate = @event.EventDate,
                EventAddress = @event.EventAddress,
                Eventhost = @event.Eventhost,
                EventType = @event.EventType
            };
            _context.SingUps.Add(singUp);
            _context.SaveChanges();

            ViewBag.MemberId = 2; //這裡應該要取得登入的會員編號


            // 假設其他報名結果邏輯...

            // 將活動信息傳遞給視圖
            return View(@event);
        }
        //取消報名
        [HttpPost]
        public IActionResult CancelRegistration(int eventId, int memberId)
        {
            // 根據活動 ID 和會員 ID 查詢報名記錄
            var signUpRecord = _context.SingUps.FirstOrDefault(s => s.EventId == eventId && s.MemberId == memberId);

            if (signUpRecord == null)
            {
                // 如果找不到相應的報名記錄，返回 NotFound 結果或其他適當的結果
                return NotFound();
            }

            try
            {
                // 刪除報名記錄
                _context.SingUps.Remove(signUpRecord);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                // 處理刪除報名記錄時可能出現的異常
                // 可以記錄日誌、返回錯誤信息等
                return BadRequest("取消報名失敗：" + ex.Message);
            }

            // 如果所有邏輯成功完成，重定向到取消報名結果頁面
            return RedirectToAction("CancellationSuccess");
        }

        public IActionResult CancellationResult(int eventId)
        {
            // 根據 eventId 從數據庫中獲取相應的活動信息
            var @event = _context.Events.FirstOrDefault(e => e.EventId == eventId);

            if (@event == null)
            {
                // 如果找不到相應的活動，返回 NotFound 結果
                return NotFound();
            }

            // 假設其他取消報名邏輯...

            // 如果所有邏輯成功完成，重定向到取消報名成功的頁面
            return RedirectToAction("CancellationSuccess");
        }
        public IActionResult CancellationSuccess()
        {
            return View();
        }

    }
}
