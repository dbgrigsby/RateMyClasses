using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateMyClasses.Models;

namespace RateMyClasses.Controllers {
	public class SearchController: Controller {
		public IActionResult Index() {
			ViewData["Title"] = "Search";
			ViewData["Message"] = "Enter in a course to search";
			return View();
		}

		public IActionResult Error() {
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

	}
}
