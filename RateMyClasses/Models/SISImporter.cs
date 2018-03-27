using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System.Xml;

namespace RateMyClasses.Models
{
    public class SISImporter
    {
        private const string SIS_URL = "http://case.edu/projects/erpextract/soc.xml";
        public string currentXmlOutputFile = "";
        
        public void downloadCurrentSISExport()
        {
            var newFileName = "sis_export_" + DateTime.Now.ToLongDateString() + ".xml";
            using (var client = new WebClient())
            {
                client.DownloadFile(SIS_URL, newFileName);
            }
            currentXmlOutputFile = newFileName;
            Console.WriteLine("XML SIS Data Downloaded.");
        }

        public void saveXmlToDatabase(string fileName)
        {
            var courses = generateCoursesFromXml(fileName);
            Console.WriteLine("Saving courses to database.");
            var coursesImported = 0;
            foreach (var course in courses)
            {
                course.SaveToDatabase();
                coursesImported += 1;
            }
            Console.WriteLine("Database import complete. Imported " + coursesImported + " courses.");
        }

        public IEnumerable<Course> generateCoursesFromXml(string filename)
        {
            Console.WriteLine("Loading XML.");
            XElement xelement;
            try
            {
                xelement = XElement.Load(filename);
            }
            catch (System.IO.FileNotFoundException e)
            {
                return new List<Course>();
            }
            
            IEnumerable<Course> courses = xelement.Descendants("Class")
                .Where(x => !(x.Element("ComponentCode").Value.Equals("REC")
                              || x.Element("ComponentCode").Value.Equals("LAB")
                              || x.Element("ComponentCode").Value.Equals("DIS")))
                .Select(item =>
                    new Course(item.Element("CourseLabel").Value, item.Element("Subject").Value,
                        item.Element("Description")?.Value));
            return courses;
        }
    }
}