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

		public ActionResult Index()
		{ 
			ViewData["Title"] = "Login";
			ViewData["Message"] = "Enter your login information to access the moderation queue";

			return View();
		}

	}
}
