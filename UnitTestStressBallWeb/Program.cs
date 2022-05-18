using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace UnitTestStressBallWeb
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "/Users/malthethomsen/Downloads";
        //private static readonly string DriverDirectory = "C://webDrivers";
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
            _driver.Navigate().GoToUrl("https://stressballwebsite.azurewebsites.net/nytkast.html");

            string title = _driver.Title;
            Assert.AreEqual("Stressball - Nyt Kast", title);


        }
        [TestMethod]
        public void TestList()
        {
            //string url = "http://localhost:3000";
            _driver.Navigate().GoToUrl("https://stressballwebsite.azurewebsites.net/liste.html");
            //_driver.Navigate().GoToUrl("http://127.0.0.1:5502/liste.html");

            string title = _driver.Title;
            Assert.AreEqual("Stressball - Liste", title);
            Thread.Sleep(1000);

            ReadOnlyCollection<IWebElement> ListElement = _driver.FindElements(By.Id("datarow"));
            Console.WriteLine(ListElement.Count());
            //IWebElement lastElement = ListElement.ElementAt(ListElement.Count - 1);
            //string lastElementText = lastElement.Text;
            //Assert.IsTrue(lastElementText.Contains("5.07"));
            Assert.IsTrue(ListElement[0].Text.Contains("0.00"));

            //Assert.IsTrue(ListTest.Text.Contains("23.00"));
            //IWebElement lastElement = ListTest.ElementAt(ListTest);
            //string updatedElementText = updatedElement.Text;


        }

        [TestMethod]
        public void TestForSide()
        {
            //string url = "http://localhost:3000";
            _driver.Navigate().GoToUrl("https://stressballwebsite.azurewebsites.net/index.html");

            string title = _driver.Title;
            Assert.AreEqual("Stressball - Forside", title);
        }
    }
}