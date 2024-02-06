using bookfortable.Models;
using bookfortable.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;


namespace bookfortable.Controllers
{
    public class EventController : Controller
    {
        private IWebHostEnvironment _environment = null;//全域變數用private
        public EventController(IWebHostEnvironment p)//寫一個建構子然後變成參數,注入後得到物件
        {
            _environment = p;
        }
        //

        public IActionResult List(CKeywordViewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<Event> datas = null;
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.Events
                        select p;
            else
                datas = db.Events.Where(p => p.EventName.Contains(vm.txtKeyword));

            return View(datas);
        }


        public ActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            Event prod = db.Events.FirstOrDefault(p => p.EventId == id);
            if (prod == null)
                return RedirectToAction("List");
            CEventWrap cp = new CEventWrap();
            cp.Events = prod;

            return View(cp);
        }

        [HttpPost]
        public ActionResult Edit(CEventWrap pIn)
        {
            FinalContext db = new FinalContext();
            Event pEdit = db.Events.FirstOrDefault(p => p.EventId == pIn.EventId);
            if (pEdit != null)
            {
                if (pIn.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    pEdit.FIamgePath = photoName;
                    pIn.photo.CopyTo(new FileStream(_environment.WebRootPath + "/images/" + photoName, FileMode.Create));
                }

                pEdit.EventName = pIn.EventName;
                pEdit.EventDate = pIn.EventDate;
                pEdit.EventTypeId = pIn.EventTypeId;
                pEdit.EventAddress = pIn.EventAddress;
                pEdit.EventhostId = pIn.EventhostId;
                db.SaveChanges();

                return RedirectToAction("List");
            }
            return View(pIn);
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                Event prod = db.Events.FirstOrDefault(p => p.EventId == id);
                if (prod != null)
                {
                    try
                    {
                        db.Events.Remove(prod);
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("具有此活動的報名表存在，無法刪除");
                        return RedirectToAction("List");
                    }

                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Event p)
        {
            FinalContext db = new FinalContext();
            db.Events.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        //public IActionResult Detail(int id)
        //{
        //Event eventDetail = db.Events.Find(id);

        //if (eventDetail == null)
        //{
        //    return NotFound();
        //}

        //// 查询与该活动关联的报名记录
        //List<SingUp> signUps = db.SignUps.Where(s => s.EventId == id).ToList();

        //// 创建 ViewModel，将活动信息和报名记录传递给视图
        //EventDetailViewModel viewModel = new EventDetailViewModel
        //{
        //    Event = eventDetail,
        //    SingUps = signUps
        //};

        //return View(viewModel);
    }
}














