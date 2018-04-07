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
	public class SearchController: Controller
	{

		private readonly CourseContext _context;

		public SearchController(CourseContext context)
		{
			_context = context;
		}

		public ActionResult Index(string nameString = "",
								  string departmentString = "",
								  string descriptionString = "")
		{ // now keyword
			ViewData["Title"] = "Search";
			ViewData["Message"] = "Enter in a course to search";

			var allCourses = from c in _context.Course
							 select c;
			var selectedCourses = allCourses;
			var noCourses = allCourses.Where(i => i.id == 0);

			// search by name
			if (!String.IsNullOrEmpty(nameString))
			{
				selectedCourses = selectedCourses.Where(c => c.name.ToLower().Contains(nameString.ToLower()));
			}

			// search by department
			if (!String.IsNullOrEmpty(departmentString))
			{
				selectedCourses = selectedCourses.Where(c => c.department.ToLower().Contains(departmentString.ToLower()));

			}

			// search by keyword, which is description and name
			if (!String.IsNullOrEmpty(descriptionString))
			{
				selectedCourses = selectedCourses.Where(c => (c.description.ToLower().Contains(descriptionString.ToLower())) ||
														(c.name.ToLower().Contains(descriptionString.ToLower())));
			}

			// After all the selections are done, we begin to format our data for testing purposes



			// if there was no search specified, return no courses
			if (String.IsNullOrEmpty(nameString) &&
				String.IsNullOrEmpty(departmentString) &&
				String.IsNullOrEmpty(descriptionString))
			{

				return View(noCourses);
			}

			else
			{
				return View(selectedCourses);
			}
		}

	}
}
