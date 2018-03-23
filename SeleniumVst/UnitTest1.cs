﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace SeleniumVst
{
    [TestClass]
    public class UnitTest1 :  CommonMethods
    {

        private IWebDriver driver;
        private string appURL;

        [TestMethod]
        [TestCategory("IE")]
        public void ValidatingFindVstInBingo()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.Id("sb_form_q")).SendKeys("VSTS");
            System.Threading.Thread.Sleep(5000);

            driver.FindElement(By.Id("sb_form_go")).Click();
            System.Threading.Thread.Sleep(5000);

            //driver.FindElement(By.XPath("//ol[@id='b_results']/li/h2/a/strong[3]")).Click();
            System.Threading.Thread.Sleep(5000);
            Assert.IsTrue(driver.Title.Contains("VSTS"), "Verified title of the page");
        }


        [TestInitialize()]
        public void SetupTest()
        {

            String path = GetCurrentProjectPath() + "/bin/Reports";

            InitReports(path, "CMS-Selenium");

            appURL = "http://www.bing.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();

            reportFlusher();
        }
    }
}