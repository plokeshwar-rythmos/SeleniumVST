using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumVst
{
    public class BeforeTestAfterTest : CommonMethods
    {
        private String testcaseID = "26";
        private static IWebDriver driver;
        private static ExtentTest test;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentXReporter xReporter;
        public static String runID;
        private static String projectID = "1";

        public void SetupReporting()
        {
            String path = GetCurrentProjectPath() + "/bin/Reports";

            //InitReports(path, "CMS-Selenium");
        }

       
    }
}

