using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RateMyClasses.Models;
// ReSharper disable Mvc.ViewNotResolved

namespace RateMyClasses.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ReviewContext _context;

        public ReviewController(ReviewContext context)
        {
            _context = context;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            return View(await _context.Review.ToListAsync());
        }

		// Shows reviews filtered by their corresponding class and aren't hidden
		public ActionResult FilterBy(long givenCourseID) {
			ViewData["Title"] = "Reviews";
			ViewData["Description"] = "The following are reviews for this course";
			var allReviews = from c in _context.Review
							 select c;

			allReviews = allReviews.Where(r => r.courseId == givenCourseID);
			allReviews = allReviews.Where(r => r.isHidden == false); // filter out hidden reviews
			return View(allReviews);
		}

		// Marks a review as reported and shows a confirmation screen
		public ActionResult Report(long reviewID) {
			ViewData["Title"] = "Report Confirmation";
			ViewData["Description"] = "Thank you for making our website a safer place. Our moderators will look over this review";

			// get the reported review
			Review reportedReview = (from r in _context.Review
									 where r.id == reviewID
									 select r).SingleOrDefault();

			// add the reported review to the list of reported reviews
			// TODO: get it a unique id, the id of the last row + 1?
			Report r2 = new Report {
				reviewID = reportedReview.id,
				reportContent = reportedReview.description,
				isHandled = false
			};

			using (var context = new ReportContext(new DbContextOptions<ReportContext>())) {
				context.Report.Add(r2);
				context.SaveChanges();
			}

			var allReviews = from c in _context.Review
							 select c;
			allReviews = allReviews.Where(r => r.courseId == reportedReview.courseId);
			return View(allReviews);

		}

        // GET: Review/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("courseId,professorName,description,dateCreated,isHidden,score")] Review review)
        {
            if (ModelState.IsValid)
            {
                _context.Add(review);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review.SingleOrDefaultAsync(m => m.id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id,courseId,professorName,description,dateCreated,isHidden,score")] Review review)
        {
            if (id != review.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(review);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewExists(review.id))
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
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var review = await _context.Review
                .SingleOrDefaultAsync(m => m.id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var review = await _context.Review.SingleOrDefaultAsync(m => m.id == id);
            _context.Review.Remove(review);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewExists(long id)
        {
            return _context.Review.Any(e => e.id == id);
        }
    }
}
