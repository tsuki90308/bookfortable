using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bookfortable.Models;
using Bookfortable.ViewModels;

namespace Bookfortable.Controllers
{
    public class ShowlistController : Controller
    {
        private readonly FinalContext _context;

        public ShowlistController(FinalContext context)
        {
            _context = context;
        }

        // GET: Showlist
        public async Task<IActionResult> Index()
        {
            var blogViewModels = await _context.Blogs
                .Select(blog => new BlogViewModel
                {
                    Blog = blog,
                    BlogImage = _context.BlogImages.FirstOrDefault(bi => bi.BlogId == blog.BlogId)
                })
                .ToListAsync();

            return View(blogViewModels);
        }

        // GET: Showlist/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogViewModel = await _context.Blogs
                .Where(blog => blog.BlogId == id)
                .Select(blog => new BlogViewModel
                {
                    Blog = blog,
                    BlogImage = _context.BlogImages.FirstOrDefault(bi => bi.BlogId == blog.BlogId)
                })
                .ToListAsync();

            if (blogViewModel == null || !blogViewModel.Any())
            {
                return NotFound();
            }

            return View(blogViewModel);
        }

        // GET: Showlist/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Showlist/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,BtagId,BlogTitle,BlogDescription,Hashtag,DateCreated")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Showlist/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Showlist/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,BtagId,BlogTitle,BlogDescription,Hashtag,DateCreated")] Blog blog)
        {
            if (id != blog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogId))
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
            return View(blog);
        }

        // GET: Showlist/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .FirstOrDefaultAsync(m => m.BlogId == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Showlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
