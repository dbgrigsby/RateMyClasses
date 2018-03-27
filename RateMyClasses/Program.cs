using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RateMyClasses.Models;

namespace RateMyClasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
           
            BuildWebHost(args).Run();
            
            //ImportAllSISCourses();
            
        }
        
        /**
         * Adds SIS classes to database
         * Don't run unless you really intend to
         */
        public static void ImportAllSISCourses()
        {
            Console.WriteLine("Importing courses from SIS. This may take a minute.....");
            var sis = new SISImporter();
            sis.downloadCurrentSISExport();
            sis.saveXmlToDatabase(sis.currentXmlOutputFile);
        }
        
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}