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
	public class LoginController: Controller
	{

		private readonly CourseContext _context;

		public LoginController(CourseContext context)
		{
			_context = context;
		}

		public ActionResult Index(Boolean error = false)
		{ 
			ViewData["Title"] = "Login";
			ViewData["Message"] = "Enter your login information to access the moderation queue";

			if (error) {
				ViewData["Error"] = "Error: Your username or password was incorrect. Please re-enter your login information";
			}

			return View();
		}

		public ActionResult Verification(String username, String password)
		{
			if (username.ToLower().Equals("adam") && password.ToLower().Equals("beck")) {
				return RedirectToAction("Index", "Moderator");	
			}
			else {
				return RedirectToAction("Index", new { error = true });
			}

		}

	}
}
