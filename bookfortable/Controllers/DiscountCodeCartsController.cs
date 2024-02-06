using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bookfortable.Models;
using bookfortable.ViewModels;

namespace bookfortable.Controllers
{
    public class DiscountCodeCartsController : Controller
    {
        private readonly FinalContext _context;

        public DiscountCodeCartsController(FinalContext context)
        {
            _context = context;
        }

        // GET: DiscountCodeCarts
        public async Task<IActionResult> Index()
        {
            return View(await _context.DiscountCodeCarts.ToListAsync());
        }

        public IActionResult List(KeywordViewModels vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<DiscountCodeCart> datas = null;

            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from p in db.DiscountCodeCarts
                        select p;
            else
                datas = db.DiscountCodeCarts.Where(p =>
                p.DiscountCode.Contains(vm.txtKeyword) ||
                p.DiscountType.Contains(vm.txtKeyword) ||
                p.PartnerName.Contains(vm.txtKeyword));

            return View(datas);
        }

        // GET: DiscountCodeCarts/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var discountCodeCart = await _context.DiscountCodeCarts
        //        .FirstOrDefaultAsync(m => m.DiscountId == id);
        //    if (discountCodeCart == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(discountCodeCart);
        //}

        // GET: DiscountCodeCarts/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: DiscountCodeCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public IActionResult Create(DiscountCodeCart d)
        {
            FinalContext db = new FinalContext();
            db.DiscountCodeCarts.Add(d);
            db.SaveChanges();
            DiscountCodeCartWrap discw = new DiscountCodeCartWrap();
            discw.discountcodecart = d;
            return RedirectToAction("List");
        }

        // GET: DiscountCodeCarts/Edit/5
        public IActionResult Edit(int? id)
        {
            FinalContext db = new FinalContext();
            DiscountCodeCart disc = db.DiscountCodeCarts.FirstOrDefault(p => p.DiscountId == id);
            if (disc == null)
                return RedirectToAction("List");
            DiscountCodeCartWrap discw = new DiscountCodeCartWrap();
            discw.discountcodecart = disc;
            return View(discw);
        }

        // POST: DiscountCodeCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public IActionResult Edit(DiscountCodeCartWrap dIn)
        {
            FinalContext db = new FinalContext();
            DiscountCodeCart dEdit = db.DiscountCodeCarts.FirstOrDefault(p => p.DiscountId == dIn.DiscountId);
            if (dEdit != null)
            {
                dEdit.DiscountCode = dIn.DiscountCode;
                dEdit.DiscountType = dIn.DiscountType;
                dEdit.DiscountStart = dIn.DiscountStart;
                dEdit.DiscountEnd = dIn.DiscountEnd;
                dEdit.IsMemberDiscount = dIn.IsMemberDiscount;
                dEdit.IsPartnerDiscount = dIn.IsPartnerDiscount;
                dEdit.PartnerName = dIn.PartnerName;
                dEdit.PartnerManager = dIn.PartnerManager;
                dEdit.PartnerManagerEmail = dIn.PartnerManagerEmail;
                dEdit.PartnerManagerPhone = dIn.PartnerManagerPhone;
                dEdit.IsActivate = dIn.IsActivate;
                dEdit.DiscountPrice = dIn.DiscountPrice;
                dEdit.DiscountNote = dIn.DiscountNote;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        // GET: DiscountCodeCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                FinalContext db = new FinalContext();
                DiscountCodeCart Disc = db.DiscountCodeCarts.FirstOrDefault(p => p.DiscountId == id);
                if (Disc != null)
                {
                    db.DiscountCodeCarts.Remove(Disc);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }

        //// POST: DiscountCodeCarts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var discountCodeCart = await _context.DiscountCodeCarts.FindAsync(id);
        //    if (discountCodeCart != null)
        //    {
        //        _context.DiscountCodeCarts.Remove(discountCodeCart);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool DiscountCodeCartExists(int id)
        {
            return _context.DiscountCodeCarts.Any(e => e.DiscountId == id);
        }
    }
}
