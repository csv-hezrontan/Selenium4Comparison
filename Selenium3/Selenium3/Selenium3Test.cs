using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Linq;

namespace Selenium3
{
    [TestClass]
    public class Selenium3Test
    {
        public string googleUrl = "https://www.google.com/";

        public string softvisionUrl = "https://www.cognizantsoftvision.com/";

        public ChromeDriver Driver { get; set; }

        [TestInitialize]
        public void Init()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void WindowManagementTest()
        {
            Driver.Navigate().GoToUrl(googleUrl);

            // Opens new window
            Driver.FindElement(By.XPath("//body")).SendKeys(Keys.Control + "N");

            // Switch to the new window
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            // Navigate to indicated url on new window
            Driver.Navigate().GoToUrl(softvisionUrl);
        }

        [TestMethod]
        public void TabManagementTest()
        {
            Driver.Navigate().GoToUrl(googleUrl);

            // Opens new tab
            ((IJavaScriptExecutor)Driver).ExecuteScript("window.open();");

            // Switch to the new tab
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());

            // Navigate to indicated url on new tab
            Driver.Navigate().GoToUrl(softvisionUrl);
        }

        [TestMethod]
        public void DesiredCapsTest()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("ACCEPT_SSL_CERTS", true);

            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("ACCEPT_SSL_CERTS", true);

            //IWebDriver driver = new ChromeDriver(capabilities);
            IWebDriver driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Close();
        }
    }
}
