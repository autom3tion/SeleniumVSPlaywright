using Microsoft.Playwright.MSTest;

namespace Playwright.Tests
{
    [TestClass]
    public class SomePageTests : PageTest
    {
        private const string PageUrl = "http://uitestingplayground.com/";

        [TestMethod]
        public async Task NavigationTest()
        {
            await Page.GotoAsync(PageUrl);
        }

        [TestMethod]
        public async Task ClickTest()
        {
            await Page.GotoAsync(PageUrl + "/Click");
            await Page.ClickAsync("#badButton");
        }

        [TestMethod]
        public async Task InputTest()
        {
            await Page.GotoAsync(PageUrl + "/textinput");
            await Page.FillAsync("#newButtonName", "sometext");
            await Page.ClickAsync("#updatingButton");
            await Expect(Page.Locator("#updatingButton")).ToHaveTextAsync("sometext");
        }

        [TestMethod]
        public async Task LoginTest()
        {
            await Page.GotoAsync(PageUrl + "/sampleapp");
            await Page.FillAsync("[name='UserName']", "user");
            await Page.FillAsync("[name='Password']", "pwd");
            await Page.ClickAsync("#login");
            await Expect(Page.Locator("#loginstatus")).ToHaveTextAsync("Welcome, user!");
        }
    }
}