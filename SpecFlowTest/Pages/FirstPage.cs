using OpenQA.Selenium;

namespace SpecFlowTest.Pages
{
    public class FirstPage
    {
        private IWebDriver _driverHelper;

        public FirstPage(IWebDriver driverHelper) => _driverHelper = driverHelper;

        public IWebElement Logo => _driverHelper.FindElement(By.TagName("time"));

        public void GotoFirstPage() => _driverHelper.Navigate().GoToUrl("http://www.vecka.nu");

        public bool IsWeekLogoDisplayed => Logo.Displayed;
    }
}