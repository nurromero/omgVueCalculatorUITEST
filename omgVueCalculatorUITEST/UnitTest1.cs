using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace vueCalculatorUITest
{
    [TestClass]
    public class UnitTest1
    {

        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver driver;

         
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TestCleanup()
        {
            driver.Quit();
        }


        [TestMethod]
        public void TestWebsite()
        {
            //Navigating to the website
            driver.Navigate().GoToUrl("https://nursvuecalculator.azurewebsites.net/");

            //Verifying the title of the page
            Assert.AreEqual("Document", driver.Title);

            //Finding the elements on the page
            IWebElement num1Element = driver.FindElement(By.Id("num1"));
            num1Element.SendKeys("45");

            IWebElement num2Element = driver.FindElement(By.Id("num2"));
            num2Element.SendKeys("20");


            // Locating the dropdown element(+ or -)
            IWebElement selectElement = driver.FindElement(By.Id("operation"));

            // Turning the dropdown element into a SelectElement
            SelectElement dropdown = new SelectElement(selectElement);
            dropdown.SelectByValue("+");

            //Finding the button and clicking it 
            IWebElement buttonElement = driver.FindElement(By.Id("calculateButton"));
            buttonElement.Click();


            IWebElement resultElement = driver.FindElement(By.Id("result"));
            Assert.AreEqual("= 65", resultElement.Text);

        }


     



    }
}
