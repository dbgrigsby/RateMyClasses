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

		private readonly StudentContext _context;

		public ModeratorController(StudentContext context) {
			_context = context;
		}

		public ActionResult Index() {
			var allCourses = from c in _context.Student
							 select c;

			return View(allCourses);

		}

	}
}
