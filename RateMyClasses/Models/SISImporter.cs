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
        }

        public void saveXmlToDatabase(string fileName)
        {
            XElement xelement = XElement.Load(currentXmlOutputFile);
            IEnumerable<Course> courses = xelement.Descendants("Class").Select(item =>
                new Course(item.Element("CourseLabel").Value, item.Element("Subject").Value, item.Element("Description")?.Value));
            foreach (var course in courses)
            {
                course.SaveToDatabase();
            }
        }
    }
}