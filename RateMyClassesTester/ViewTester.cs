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

namespace RateMyClasses
{
    public class ViewTester
    {
        [Fact]
        public void HomeAboutViewTest()
        {
            ViewResult homeAboutView = (ViewResult)new HomeController().About();
            var viewDataH = homeAboutView.ViewData;

            Assert.True(viewDataH["Message"].Equals("Rate My Classes - A crowdsourced rating and review system"));
        }


        [Fact]
        public void HomeContactViewTest()
        {

            ViewResult homeContactView = (ViewResult)new HomeController().Contact();
            var viewDataC = homeContactView.ViewData;

            Assert.True(viewDataC["Message"].Equals("Please leave us any questions, comments, or concerns"));

        }


        [Fact]
        public void SearchViewTests()
        {

            CourseContext c = new CourseContext(new DbContextOptions<CourseContext>());
            ViewResult v = (ViewResult)new SearchController(c).Index();
            var viewData = v.ViewData;

            Assert.True(viewData["Message"].Equals("Enter in a course to search"));
        }

        
    }
}

