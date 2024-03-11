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
            IWebElement num1Element = driver.FindElement(By.CssSelector("input[type='number']:nth-of-type(1)"));
            num1Element.SendKeys("45");

            IWebElement num2Element = driver.FindElement(By.CssSelector("input[type='number']:nth-of-type(2)"));
            num2Element.SendKeys("20");

            IWebElement selectElement = driver.FindElement(By.CssSelector("select"));

            //Finding the button and clicking it 
            IWebElement buttonElement = driver.FindElement(By.CssSelector("button.btn-primary"));
            buttonElement.Click();

            //Find the result element, verifying/asserting it 
            //Using last.child, because the result is the last element in the result-container (D:) 
            IWebElement resultElement = driver.FindElement(By.CssSelector(".result-container > div:last-child"));
            Assert.AreEqual("Result: 65", resultElement.Text);

        }


        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }




    }
}
