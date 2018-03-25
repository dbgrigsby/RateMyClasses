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
	public class ReviewController: Controller {
		private readonly StudentContext _context;

		public ReviewController(StudentContext context) {
			_context = context;
		}

		public ActionResult Index(int? id) {
			ViewData["Title"] = "Reviews";
			ViewData["Message"] = "The following are a list of reviews for this course";

			if (id == null) {
				return NotFound();
			}

			var allStudents = from s in _context.Student
							  select s;

			return View(allStudents);
		}

		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}