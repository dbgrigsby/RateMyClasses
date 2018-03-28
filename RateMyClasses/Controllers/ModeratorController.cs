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

namespace RateMyClasses.Controllers {
	public class ModeratorController: Controller {

		private readonly ReportContext _context;

		public ModeratorController(ReportContext context) {
			_context = context;
		}

		public ActionResult Index() {
			var allReports = from c in _context.Report
							 select c;

			return View(allReports);
		}

		// Hides a review from being public
		public ActionResult Hide(long reviewID) {

			//TODO: acccess review table and mark all as hidden

			var newAllReports = from c in _context.Report
								where c.reviewID == reviewID
								select c;

			_context.Report.RemoveRange(newAllReports);
			_context.SaveChanges();

			var allReports = from c2 in _context.Report
							 select c2;		
			return View(allReports);
		}

		// Hides a review from being public
		public ActionResult Approve(long reviewID) {

			//TODO: acccess review table and mark all as hidden

			var newAllReports = from c in _context.Report
								where c.reviewID == reviewID
								select c;

			_context.Report.RemoveRange(newAllReports);
			_context.SaveChanges();

			var allReports = from c2 in _context.Report
							 select c2;
			return View(allReports);
		}

	}
}
