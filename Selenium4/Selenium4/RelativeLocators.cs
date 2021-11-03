using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium4
{
    [TestClass]
    public class RelativeLocators
    {
        public ChromeDriver Driver { get; set; }

        [TestInitialize]
        public void Init()
        {
            Driver = new ChromeDriver();
        }

        [TestMethod]
        public void RelativeLocatorTest()
        {
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://magenicautomation.azurewebsites.net/Static/Training3/loginpage.html");


            IWebElement usernameField = Driver.FindElement(By.Id("name"));
            IWebElement passwordField = Driver.FindElement(By.Id("pw"));
            IWebElement loginButton = Driver.FindElement(RelativeBy.WithLocator(By.TagName("button")).Below(passwordField));
            
            usernameField.SendKeys("Ted");
            passwordField.SendKeys("123");
            loginButton.Click();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }
    }
}
