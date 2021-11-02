using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium4
{
    [TestClass]
    public class Selenium4Test
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

            // Opens a new window and switches to the new window
            Driver.SwitchTo().NewWindow(WindowType.Window);

            // Opens URL in the newly opened window
            Driver.Navigate().GoToUrl(softvisionUrl);
        }

        [TestMethod]
        public void TabManagementTest()
        {
            Driver.Navigate().GoToUrl(googleUrl);

            // Opens a new tab in an existing tab
            Driver.SwitchTo().NewWindow(WindowType.Tab);

            // Opens URL in the newly opened tab
            Driver.Navigate().GoToUrl(softvisionUrl);
        }

        [TestMethod]
        public void DeprecatedDesiredCapsTest()
        {
            // DesiredCapabilities // Cannot be referenced anymore
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalOption("ACCEPT_SSL_CERTS", true);
            // Add Additional Capability is deprecated
            options.AddAdditionalCapability("VERSION", "95");
             
            var driver = new ChromeDriver(options);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Dispose();
        }
    }
}
