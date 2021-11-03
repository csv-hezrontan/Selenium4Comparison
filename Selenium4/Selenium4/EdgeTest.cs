using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Selenium4
{
    [TestClass]
    public class EdgeTest
    {
        [TestMethod]
        public void EdgeBrowserTest()
        {
            IWebDriver driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Close();
        }
    }
}
