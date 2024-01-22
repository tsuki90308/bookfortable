using bookfortable.Models;
using Microsoft.AspNetCore.Mvc;

namespace bookfortable.Controllers
{
    public class EventController : Controller
    {
        public IActionResult List()
        {
            //1
            FinalContext db = new FinalContext();
            var datas = from p in db.Events
                        select p;
            return View(datas);
        }
        public ActionResult Delete(int id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                Event cust = db.Events.FirstOrDefault(p => p.EventId == id);
                if (cust != null)
                {
                    db.Events.Remove(cust);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public IActionResult Create(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Event p)
        {
            FinalContext db = new FinalContext();
            db.Events.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }


    }
}
