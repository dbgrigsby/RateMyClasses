using System;
using Xunit;
using RateMyClasses.Controllers;
using RateMyClasses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Data.Sqlite;
using Moq;



namespace RateMyClassesTester
{
    public class ControllerTester
    {

        /* ----- SearchController ----- */

		// Index, empty path
        [Fact]
        public void Empty_Search_Query()
        {
            CourseContext c = new CourseContext(new DbContextOptions<CourseContext>());
            var result = new SearchController(c).Index() as ViewResult;
            var viewData = result.ViewData;

            Assert.True(viewData["Result"].Equals("0"));
        }

		// Index, nonempty path
        [Fact]
        public void One_Or_More_Search_Query()
        {
			var dbsource = Environment.CurrentDirectory + "/RateMyClasses.db";
			var connectionsCourse = new SqliteConnection("Data Source=" + dbsource);
			var optionsCourse = new DbContextOptionsBuilder<CourseContext>().UseSqlite(connectionsCourse).Options;

			CourseContext a = new CourseContext(optionsCourse);

			var result = new SearchController(a).Index("132", "", "") as ViewResult;
			var viewData = result.ViewData;


			Assert.True(viewData["Result"].Equals("1"));
        }


        /* ----- ModeratorController ----- */
		// Index
        [Fact]
        public void All_Reviews_Listed_Moderator()
        {
            var dbsource = Environment.CurrentDirectory + "/RateMyClasses.db"; 
            
            var connectionsReview = new SqliteConnection("Data Source=" + dbsource);
            var optionsReview = new DbContextOptionsBuilder<ReviewContext>() .UseSqlite(connectionsReview).Options;
            
            var connectionReport = new SqliteConnection("Data Source=" + dbsource);
            var optionsReport = new DbContextOptionsBuilder<ReportContext>() .UseSqlite(connectionReport).Options;
            
            ReviewContext a = new ReviewContext(optionsReview);
            ReportContext b = new ReportContext(optionsReport);

            var result = new ModeratorController(b, a).Index() as ViewResult;
            var viewData = result.ViewData;


            Assert.True(!viewData["Result"].Equals("example"));
        }

		// Hide
		[Fact]
		public void Hide_Review()
		{
			var dbsource = Environment.CurrentDirectory + "/RateMyClasses.db";

			var connectionsReview = new SqliteConnection("Data Source=" + dbsource);
			var optionsReview = new DbContextOptionsBuilder<ReviewContext>().UseSqlite(connectionsReview).Options;

			var connectionReport = new SqliteConnection("Data Source=" + dbsource);
			var optionsReport = new DbContextOptionsBuilder<ReportContext>().UseSqlite(connectionReport).Options;

			ReviewContext a = new ReviewContext(optionsReview);
			ReportContext b = new ReportContext(optionsReport);

			var result = new ModeratorController(b, a).Hide(30133) as ViewResult;
			var viewData = result.ViewData;


			Assert.True(viewData["Result"].Equals("Hidden"));
		}

		// Approve
		[Fact]
		public void Approve_Review()
		{
			var dbsource = Environment.CurrentDirectory + "/RateMyClasses.db";

			var connectionsReview = new SqliteConnection("Data Source=" + dbsource);
			var optionsReview = new DbContextOptionsBuilder<ReviewContext>().UseSqlite(connectionsReview).Options;

			var connectionReport = new SqliteConnection("Data Source=" + dbsource);
			var optionsReport = new DbContextOptionsBuilder<ReportContext>().UseSqlite(connectionReport).Options;

			ReviewContext a = new ReviewContext(optionsReview);
			ReportContext b = new ReportContext(optionsReport);

			var result = new ModeratorController(b, a).Approve(30133) as ViewResult;
			var viewData = result.ViewData;


			Assert.True(viewData["Result"].Equals("Approved"));
		}

		/* ----- ReviewController already satisfied from the mock test ----- */




        [Fact]
        public void TestingMock()
        {

            //create a list of review 
            var r1 = new Review();
            r1.courseId = 1;
            r1.description = "cool cool";


            var r2 = new Review();
            r2.courseId = -1;
            r2.description = "super hard";


            var r3 = new Review();
            r3.courseId = 3;
            r3.description = "very easy";


            var r4 = new Review();
            r4.courseId = 4;
            r4.description = "ruined my life";


            var reviews = new List<Review>{
                r1,r2,r3,r4,

            }.AsQueryable();

            var reviewMock = new Mock<DbSet<Review>>();
            reviewMock.As<IQueryable<Review>>().Setup(m => m.Provider).Returns(reviews.Provider);
            reviewMock.As<IQueryable<Review>>().Setup(m => m.Expression).Returns(reviews.Expression);
            reviewMock.As<IQueryable<Review>>().Setup(m => m.ElementType).Returns(reviews.ElementType);
            reviewMock.As<IQueryable<Review>>().Setup(m => m.GetEnumerator()).Returns(reviews.GetEnumerator());

            var mockedContext = new Mock<IDbContext>();

            mockedContext.Setup(p => p.Review).Returns(reviewMock.Object);

            var test = mockedContext.Object;


            var hope = test.Review;

            var c = hope.Count<Review>();

            var controller = new ReviewController(test);

			var tmpDontDelete = controller.Report(3); // for code coverage
            var result = controller.FilterBy(1) as ViewResult;

            var viewData = result.ViewData;


            var model = (IEnumerable<RateMyClasses.Models.Review>)result.Model;


            var modelList = model.ToList<Review>();

            Assert.True(model.Count<Review>() == 1);

            Assert.True(modelList.First<Review>().description == "cool cool");
            //var m = result.Model;

            //var test2 = viewData.Model;

            Assert.Equal("cool cool", modelList.First<Review>().description);
            //Assert.Equal(!viewData["Result"].Equals("example"));

        }

    }

}