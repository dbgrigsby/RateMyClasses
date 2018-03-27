using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using RateMyClasses;

namespace RateMyClassesTester
{
    public class SISImporterTester
    {
    // format for method names: MethodName_WhatsBeingTested_ExpectedResult

        private static RateMyClasses.Models.SISImporter importer;
        
        [Fact]
        public void DownloadSISData_ValidState_GeneratesCorrectFile()
        {
            // setup 
            importer = new RateMyClasses.Models.SISImporter();
            var SIS_OUTPUT_FILE_FORMAT_PREFIX = "sis_export_";
            var SIS_OUTPUT_FILE_FORMAT_SUFFIX = ".xml";
            
            // test
            importer.downloadCurrentSISExport();
            Assert.True(importer.currentXmlOutputFile.StartsWith(SIS_OUTPUT_FILE_FORMAT_PREFIX));
            Assert.True(importer.currentXmlOutputFile.EndsWith(SIS_OUTPUT_FILE_FORMAT_SUFFIX));
            
            // reset state
            importer = null;
        }
        
        [Fact]
        public void GenerateCoursesFromXML_ValidFilename_CourseListReturned()
        {
            // setup 
            importer = new RateMyClasses.Models.SISImporter();
            importer.downloadCurrentSISExport();
            
            // test
            IEnumerable<RateMyClasses.Models.Course> courses = importer.generateCoursesFromXml(importer.currentXmlOutputFile);
            Assert.True(courses.ToList().Count > 3000);
            
            // reset state
            importer = null;
        }
        
        [Fact]
        public void GenerateCoursesFromXML_InvalidFilename_NoCoursesReturned_()
        {
            // setup 
            importer = new RateMyClasses.Models.SISImporter();
            var INVALID_FILE_NAME = "84983j43ojioj439.txt";
            
            // test
            IEnumerable<RateMyClasses.Models.Course> courses = importer.generateCoursesFromXml(INVALID_FILE_NAME);
            Assert.True(courses.ToList().Count == 0);
            
            // reset state
            importer = null;
        }
    }
}