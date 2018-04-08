using Xunit;
using RateMyClasses.Controllers;
using RateMyClasses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace RateMyClassesTester
{
	public class ControllerTester
	{

		// SearchController
		[Fact]
		public void Empty_Search_Query() 
		{
			CourseContext c = new CourseContext(new DbContextOptions<CourseContext>());
			var result = new SearchController(c).Index() as ViewResult;
			var viewData = result.ViewData;

			Assert.True(viewData["Result"].Equals("0"));
		}

		[Fact]
		public void One_Or_More_Search_Query()
		{
			CourseContext c = new CourseContext(new DbContextOptions<CourseContext>());
			var result = new SearchController(c).Index("132", "", "") as ViewResult;
			var viewData = result.ViewData;

			Assert.True(viewData["Result"].Equals("1"));
		}


		// ReviewController
		[Fact]
		public void No_Reviews_Filter()
		{
			ReviewContext c = new ReviewContext(new DbContextOptions<ReviewContext>());
			var result = new ReviewController(c).FilterBy() as ViewResult;
			var viewData = result.ViewData;

			Assert.True(viewData["Result"].Equals("0"));
		}

		// ModeratorController
		[Fact]
		public void All_Reviews_Listed_Moderator()
		{
			ReviewContext a = new ReviewContext(new DbContextOptions<ReviewContext>());
			ReportContext b = new ReportContext(new DbContextOptions<ReportContext>());

			var result = new ModeratorController(b, a).Index() as ViewResult;
			var viewData = result.ViewData;


			Assert.True(!viewData["Result"].Equals("example"));
		}

	}


}