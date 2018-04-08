using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateMyClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
	public class ModeratorController: Controller
	{

		private readonly ReportContext _context;
		private readonly ReviewContext _reviewContext;

		public ModeratorController(ReportContext context, ReviewContext reviewContext)
		{
			_context = context;
			_reviewContext = reviewContext;
		}

		public ActionResult Index()
		{
			var allReports = from c in _context.Report
							 select c;

			ViewData["Result"] = allReports.ToList().Count().ToString();
			return View(allReports);
		}

		// Hides a review from being public
		public ActionResult Hide(long reviewID)
		{
			var newAllReports = from c in _context.Report
								where c.reviewID == reviewID
								select c;

			var reviewToHide = (from r in _reviewContext.Review
								where r.id == reviewID
								select r).SingleOrDefault();

			reviewToHide.isHidden = true;

			_reviewContext.SaveChanges();


			_context.Report.RemoveRange(newAllReports);
			_context.SaveChanges();

			var allReports = from c2 in _context.Report
							 select c2;
			return View(allReports);
		}

		// Approves a review, nothing happens to the review, but the reports get deleted from the moderation queue
		public ActionResult Approve(long reviewID)
		{
			var reportsToDelete = from c in _context.Report
								  where c.reviewID == reviewID
								  select c;

			_context.Report.RemoveRange(reportsToDelete);
			_context.SaveChanges();

			var allReports = from c2 in _context.Report
							 select c2;
			return View(allReports);
		}

	}
}
