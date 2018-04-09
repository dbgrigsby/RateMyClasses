using Xunit;
using RateMyClasses.Controllers;
using RateMyClasses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Moq;


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


        [Fact]
        public void TestingMock()
        {

            //create a list of review 
            var r1 = new Review();
            r1.courseId = 1;
            r1.description = "cool cool";


            var r2 = new Review();
            r2.courseId = 2;
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


            var reviewContextMock = new Mock<ReviewContext>();
            //var reviewContextMock = new Mock<IModel>();
            reviewContextMock.Setup(x => x.Review).Returns(reviewMock.Object);

            var test = reviewContextMock.Object;

            //var rc = test.GetContext();

            var controller = new ReviewController(test);

            var result = controller.FilterBy() as ViewResult;

            var viewData = result.ViewData;


            Assert.True(!viewData["Result"].Equals("example"));

        }

    }

}