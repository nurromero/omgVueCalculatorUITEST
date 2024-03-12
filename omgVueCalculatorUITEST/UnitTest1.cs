using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace vueCalculatorUITest
{
    [TestClass]
    public class UnitTest1
    {

        private static readonly string DriverDirectory = "C:\\Users\\baddi\\OneDrive\\Skrivebord\\Programmering - 3rd semester\\webDrivers";
        private IWebDriver driver;


        [TestInitialize]
        public void TestInitialize()
        {
            driver = new ChromeDriver(DriverDirectory);
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

            IWebElement selectElement = driver.FindElement(By.Id("operation"));

            //Finding the button and clicking it 
            IWebElement buttonElement = driver.FindElement(By.Id("calculatebutton"));
            buttonElement.Click();


            IWebElement resultElement = driver.FindElement(By.Id("result"));
            Assert.AreEqual("Result: 65", resultElement.Text);

        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }




    }
}
