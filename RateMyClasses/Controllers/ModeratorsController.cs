using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMyClasses.Models;

namespace RateMyClasses.Controllers
{
    public class ModeratorsController : Controller
    {
        private readonly ModeratorsContext _context;

        public ModeratorsController(ModeratorsContext context)
        {
            _context = context;
        }

        // GET: Moderators
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moderators.ToListAsync());
        }

        // GET: Moderators/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderators = await _context.Moderators
                .SingleOrDefaultAsync(m => m.id == id);
            if (moderators == null)
            {
                return NotFound();
            }

            return View(moderators);
        }

        // GET: Moderators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moderators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,hash")] Moderators moderators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moderators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moderators);
        }

        // GET: Moderators/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderators = await _context.Moderators.SingleOrDefaultAsync(m => m.id == id);
            if (moderators == null)
            {
                return NotFound();
            }
            return View(moderators);
        }

        // POST: Moderators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,name,hash")] Moderators moderators)
        {
            if (id != moderators.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moderators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeratorsExists(moderators.id))
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
            return View(moderators);
        }

        // GET: Moderators/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moderators = await _context.Moderators
                .SingleOrDefaultAsync(m => m.id == id);
            if (moderators == null)
            {
                return NotFound();
            }

            return View(moderators);
        }

        // POST: Moderators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var moderators = await _context.Moderators.SingleOrDefaultAsync(m => m.id == id);
            _context.Moderators.Remove(moderators);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeratorsExists(long id)
        {
            return _context.Moderators.Any(e => e.id == id);
        }
    }
}
