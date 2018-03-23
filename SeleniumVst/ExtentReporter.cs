﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SeleniumVst
{
    public class ExtentReporter
    {
        ExtentHtmlReporter htmlReporter;
        static ExtentReports reporter;
        static ExtentTest parent;
        static ExtentTest test;


        public static ExtentHtmlReporter getHtmlReport()
        {
            String path = getCurrentProjectPath() + "/bin/Reports";
            new CommonMethods().createDirectory(path);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path + "/Automation-" + getTimeStamp() + ".html");
            htmlReporter.Configuration().Theme = Theme.Dark;
            htmlReporter.Configuration().DocumentTitle = "DocWorks Selenium Report";
            htmlReporter.Configuration().ReportName = "DocWorks Selenium Testing Report";
            return htmlReporter;
        }

        

        public static string getCurrentProjectPath()
        {
            String path = System.AppDomain.CurrentDomain.BaseDirectory;
            path = path.Substring(0, path.IndexOf(@"\bin"));
            return path;
        }
        public static string getTimeStamp()
        {
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString());
            TimeAndDate.Replace("/", "_");
            TimeAndDate.Replace(":", "_");
            return TimeAndDate.ToString();
        }
        /**
        * Method creates instance of extent and creates html with reportName and in folderPath.
        * @param folderPath
        * @param reportName
        */
        public static void InitReports(String folderPath, String reportName)
        {
            Console.WriteLine("Initializing Extent Reporting");
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(folderPath + "/" + reportName + getTimeStamp() + ".html");
            htmlReporter.Configuration().ReportName = reportName;
            htmlReporter.Configuration().DocumentTitle = reportName;
            reporter = new ExtentReports();
            reporter.AttachReporter(htmlReporter);
        }
        /**
         * Method creates instance of extent with ExtentX Server connection.
         * @param folderPath
         * @param reportName
         * @param mongoDBUrl
         * @param serverUrl
         * @param projectName
         */
        public void InitReports(String folderPath, String reportName, String mongoDBUrl, String serverUrl,
                String projectName)
        {
            ExtentXReporter xReporter = new ExtentXReporter(mongoDBUrl);
            xReporter.Configuration().ServerURL = serverUrl;
            xReporter.Configuration().ReportName = reportName;
            xReporter.Configuration().ProjectName = projectName;
            htmlReporter = new ExtentHtmlReporter(folderPath + "/" + reportName + ".html");
            htmlReporter.Configuration().ReportName = reportName;
            htmlReporter.Configuration().DocumentTitle = reportName;
            reporter = new ExtentReports();
            reporter.AttachReporter(htmlReporter, xReporter);
        }
        /**
         * Method creates a new instance of test with just testcase name.
         * @param testCaseName
         */
        public void CreateTest(String testCaseName)
        {

            Console.WriteLine("Creating test");
            test = reporter.CreateTest(testCaseName);

        }
        /**
         * Method creates a new instance of test with testcase name and test description.
         * @param testCaseName
         * @param description
         */
        public void CreateTest(String testCaseName, String description)
        {

            Console.WriteLine("Creating test Case");
            test = reporter.CreateTest(testCaseName, description);


        }
        /**
         * This method creates a new instance of parent test with testcase name.
         * 
         * @param testCaseName
         */
        public void CreateParentTest(String testCaseName)
        {
            parent = reporter.CreateTest(testCaseName);
            Console.WriteLine("Creating Parent Test. : " + parent);
        }
        /**
         * This method closes the current parent test instance.
         */
        public void closeParentTest()
        {
            Console.WriteLine("Closing Parent Test : " + parent);
            if (parent != null)
                parent = null;
        }
        /**
         * This method adds a pass statement to the current test instance.
         * @param description
         */
        public void pass(String description)
        {
            Console.WriteLine("PASS : " + description);
            test.Pass(description);
        }
        /**
         * This method adds a fail statement to the current test instance.
         * @param description
         */
        public void fail(String description)
        {
            Console.WriteLine("FAIL : " + description);
            test.Fail("<div style=\"color: red;\">" + description + "</div>");
        }
        /**
         * This method adds a info statement to the current test instance.
         * @param description
         */
        public void info(String description)
        {
            Console.WriteLine("INFO : " + description);
            test.Info(description);
        }
        /**
         * This method flushes report to the active extent instance.
         */
        public void reportFlusher()
        {
            Console.WriteLine("Flushing the HTML report.");
            reporter.Flush();
        }
      
    }
}

