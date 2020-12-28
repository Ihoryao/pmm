using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class SageController : Controller
    {
        private readonly SageBookContext _context;

        public SageController(SageBookContext context)
        {
            _context = context;
        }


        // GET: Sage/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sages.ToListAsync());
        }

        // GET: Sage/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _context.Sages.FindAsync(id);
            if (sage == null)
            {
                return NotFound();
            }

            return View(sage);
        }

        // POST: Sage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SageId,Name,Age,Photo,City")] Sage sage)
        {
            if (id != sage.SageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // if (!MovieExists(sage.SageId))
                    // {
                    //     return NotFound();
                    // }
                    // else
                    // {
                    //     throw;
                    // }
                }

                return RedirectToAction("Index");
            }

            return View(sage);
        }

        // GET: Sage/Create/5
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sage/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("SageId,Name,Age,Photo,City")] Sage sage)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Sages.Add(sage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists " +
                                             "see your system administrator.");
            }

            return View(sage);
        }

        // GET: Sage/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _context.Sages
                .FirstOrDefaultAsync(s => s.SageId == id);
            if (sage == null)
            {
                return NotFound();
            }

            return View(sage);
        }

        // GET: Sage/SageBooks
        [HttpGet]
        public IActionResult SageBooks(int? id)
        {
            var query = from book in _context.Books
                where book.Sages.Any(s => s.SageId == id)
                select book;

            return View(query.ToList());
        }

        // GET: Sage/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sage = await _context.Sages
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SageId == id);
            if (sage == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }

            return View(sage);
        }

        // POST: Sage/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sage = await _context.Sages.FindAsync(id);
            if (sage == null)
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                _context.Sages.Remove(sage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true});
            }
        }
    }
}