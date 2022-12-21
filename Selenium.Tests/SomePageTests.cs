using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium.Tests
{
    [TestClass]
    public class SomePageTests 
    { 
        private IWebDriver webDriver;
        private const string PageUrl = "http://uitestingplayground.com/";

        [TestInitialize]
        public void TestInit()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            webDriver = new ChromeDriver(options);
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [TestCleanup]
        public void TearDown()
        {
            webDriver.Quit();
        }

        [TestMethod]
        public void NavigationTest()
        {
            webDriver.Navigate().GoToUrl(PageUrl);
        }

        [TestMethod]
        public void ClickTest()
        {
            webDriver.Navigate().GoToUrl(PageUrl + "/Click");
            webDriver.FindElement(By.Id("badButton")).Click();
        }

        [TestMethod]
        public void InputTest()
        {
            webDriver.Navigate().GoToUrl(PageUrl + "/textinput");
            webDriver.FindElement(By.Id("newButtonName")).SendKeys("sometext");
            webDriver.FindElement(By.Id("updatingButton")).Click();

            var updatedButtonText = webDriver.FindElement(By.Id("updatingButton")).Text;
            Assert.AreEqual("sometext", updatedButtonText);
        }

        [TestMethod]
        public void LoginTest()
        {
            webDriver.Navigate().GoToUrl(PageUrl + "/sampleapp");
            webDriver.FindElement(By.Name("UserName")).SendKeys("user");
            webDriver.FindElement(By.Name("Password")).SendKeys("pwd");
            webDriver.FindElement(By.Id("login")).Click();
            var statusText = webDriver.FindElement(By.Id("loginstatus")).Text;
            Assert.AreEqual("Welcome, user!", statusText);
        }
    }
}