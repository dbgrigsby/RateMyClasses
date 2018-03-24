using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RateMyClasses.Models;

namespace RateMyClasses.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
			ViewData["Message"] = "Rate My Classes - A crowdsourced rating and review system";
			ViewData["Description"] = @"
The Rate My Classes System is a crowd-sourced course rating and review System for university classes,
 beginning with those at Case Western Reserve University. Contrib- utors will be
 able to anonymously rate class based on several criteria, such as class diculty
, workload, and whether or not a class is more challenging with certain professors.
 Contributors can also list additional information about a class such as whether
 or not they recommend taking the class and other classes that helped prepare them for
 this class. All this information will be available upon searching for a class by either its
 name or the abbreviated department name and class number. Users can scroll through
 the list of classes and get first hand review and suggestions from Contributors that have
 already taken classes at Case Western Reserve University. ";
			return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Please leave us any questions, comments, or concerns";
			ViewData["Description"] = "Contributors for Rate My Classes:";
			return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
