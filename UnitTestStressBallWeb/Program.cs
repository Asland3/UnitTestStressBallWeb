using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace UnitTestStressBallWeb
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "/Users/malthethomsen/Downloads";
        private static IWebDriver _driver;
        
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
             _driver = new ChromeDriver(DriverDirectory); 
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestNytKast()
        {
            //string url = "http://localhost:3000";
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/nytkast.html");
            
            string title = _driver.Title;
            Assert.AreEqual("Stressball - Nyt Kast", title);
            
            IWebElement buttonElement = _driver.FindElement(By.Id("button"));
            buttonElement.Click();
        }
        [TestMethod]
        public void TestList()
        {
            //string url = "http://localhost:3000";
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/nytkast.html");
            
            string title = _driver.Title;
            Assert.AreEqual("Stressball - Liste", title);
        }
        
        [TestMethod]
        public void TestForSide()
        {
            //string url = "http://localhost:3000";
            _driver.Navigate().GoToUrl("http://127.0.0.1:5501/nytkast.html");
            
            string title = _driver.Title;
            Assert.AreEqual("Stressball - Forside", title);
        }
    }
}


