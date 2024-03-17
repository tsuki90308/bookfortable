using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bookfortable.Models;
using Bookfortable.ViewModels;

namespace Bookfortable.Controllers
{
    public class TempBoxesController : Controller
    {
        private readonly FinalContext _context;

        private IWebHostEnvironment _environment;

        public TempBoxesController(IWebHostEnvironment p)
        {
            _environment = p;
        }
        public IActionResult List(CKeywordViewModel vm)
        {
            FinalContext db = new FinalContext();
            IEnumerable<TempBox> datas = null;


            return View(datas);
        }

        // GET: TempBoxes
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TempBoxes.ToListAsync());
        //}

        // GET: TempBoxes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempBox = await _context.TempBoxes
                .FirstOrDefaultAsync(m => m.BoxId == id);
            if (tempBox == null)
            {
                return NotFound();
            }

            return View(tempBox);
        }

        // GET: TempBoxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TempBoxes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BoxId,Price,BookTag2string")] TempBox tempBox)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tempBox);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tempBox);
        }

        // GET: TempBoxes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempBox = await _context.TempBoxes.FindAsync(id);
            if (tempBox == null)
            {
                return NotFound();
            }
            return View(tempBox);
        }

        // POST: TempBoxes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoxId,Price,BookTag2string")] TempBox tempBox)
        {
            if (id != tempBox.BoxId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tempBox);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TempBoxExists(tempBox.BoxId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tempBox);
        }

        // GET: TempBoxes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tempBox = await _context.TempBoxes
                .FirstOrDefaultAsync(m => m.BoxId == id);
            if (tempBox == null)
            {
                return NotFound();
            }

            return View(tempBox);
        }

        // POST: TempBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tempBox = await _context.TempBoxes.FindAsync(id);
            if (tempBox != null)
            {
                _context.TempBoxes.Remove(tempBox);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TempBoxExists(int id)
        {
            return _context.TempBoxes.Any(e => e.BoxId == id);
        }
    }
}
