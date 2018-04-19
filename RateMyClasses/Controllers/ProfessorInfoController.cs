using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateMyClasses.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RateMyClasses.Controllers
{
	public class ProfessorInfoController: Controller
	{

		private readonly ReviewContext _context;

		public ProfessorInfoController(ReviewContext context)
		{
			_context = context;
		}

		public ActionResult Index(String professorName)
		{
			ViewData["Title"] = "Professor Information";
			ViewData["Message"] = "Here are all the reviews that exist for professor " + professorName + ".";

			var allReviews = from r in _context.Review
				             where r.professorName.ToLower().Equals(professorName.ToLower()) && r.isHidden == false
							 select r;

			return View(allReviews);
		}
	}
}
