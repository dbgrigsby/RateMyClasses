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
	public class SearchController: Controller {

		private readonly CourseContext _context;

		public SearchController(CourseContext context) {
			_context = context;
		}

		public ActionResult Index(string searchString = "") {
			ViewData["Title"] = "Search";
			ViewData["Message"] = "Enter in a course to search";

			var allCourses = from c in _context.Course
							 select c;

			var noCourses = allCourses.Where(i => i.id == 0);

			if (String.IsNullOrEmpty(searchString)) {
				return View(noCourses);
			}

			else {
				var selectedCourses = allCourses.Where(c => c.name.ToLower().Contains(searchString.ToLower()));
				return View(selectedCourses);
			}
		}

		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}
