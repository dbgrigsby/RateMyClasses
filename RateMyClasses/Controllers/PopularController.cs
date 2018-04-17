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
	public class PopularController: Controller
	{

		private readonly ReviewContext _context;

		public PopularController(ReviewContext context)
		{
			_context = context;
		}

		public ActionResult Index()
		{
			ViewData["Title"] = "Highest Rated Professors";
			ViewData["Message"] = "Here are reviews with the highest scores.";

			var allReviews = from r in _context.Review
							 where r.score >= 8
							 select r;

			return View(allReviews);
		}
	}
}
