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

		public ActionResult Index(string nameString = "",
								  string departmentString = "",
								  string descriptionString = "") {
			ViewData["Title"] = "Search";
			ViewData["Message"] = "Enter in a course to search";

			var allCourses = from c in _context.Course
							 select c;

			var noCourses = allCourses.Where(i => i.id == 0);

			// search by name
			if (!String.IsNullOrEmpty(nameString)) {
				var selectedCourses = allCourses.Where(c => c.name.ToLower().Contains(nameString.ToLower()));
				return View(selectedCourses);
			}

			// search by department
			else if (!String.IsNullOrEmpty(departmentString)) {
				var selectedCourses = allCourses.Where(c => c.department.ToLower().Contains(departmentString.ToLower()));
				return View(selectedCourses);
			}

			// search by description
			else if (!String.IsNullOrEmpty(descriptionString)) {
				var selectedCourses = allCourses.Where(c => c.description.ToLower().Contains(descriptionString.ToLower()));
				return View(selectedCourses);
			}

			// default, no table listed
			else {
				return View(noCourses);
			}
		}

	}
}
