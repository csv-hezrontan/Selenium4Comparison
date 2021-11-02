using Microsoft.Edge.SeleniumTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Selenium3
{
    [TestClass]
    public class EdgeTest
    {
        [TestMethod]
        public void EdgeDriverTest()
        {
            // References Microsoft.Edge.SeleniumTools instead of OpenQA.Selenium.Edge
            // Need to add option UseChromium = true, else it will reference the Edge Legacy
            EdgeOptions options = new EdgeOptions();
            options.UseChromium = true;
            IWebDriver driver = new EdgeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.Dispose();
        }
    }
}
