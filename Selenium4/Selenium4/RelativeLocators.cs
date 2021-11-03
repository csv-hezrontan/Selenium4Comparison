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
            IWebElement loginButton = Driver.FindElement(RelativeBy.WithLocator(By.TagName("button")).Below(usernameField));
            
            usernameField.SendKeys("Ted");
            passwordField.SendKeys("123");
            loginButton.Click();

            IWebElement navigationBar = Driver.FindElement(By.CssSelector("table.Nav"));
            IWebElement howItWorksPageButton = Driver.FindElement(By.Id("HowWorkPage"));
            Assert.IsTrue(howItWorksPageButton.Displayed);
            
            IWebElement header = Driver.FindElement(RelativeBy.WithLocator(By.TagName("p")).Below(navigationBar));
            string headerText = header.Text.Trim();
            string expectedHeader = "Welcome Home";
            Assert.AreEqual(headerText, expectedHeader);

            //IWebElement body = Driver.FindElement(By.XPath("//p[text()='We blah blah blah']"));
            //IWebElement secondPara = Driver.FindElement(RelativeBy.WithLocator(By.TagName("p")).Near(body));
            //string text = secondPara.Text.Trim();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
