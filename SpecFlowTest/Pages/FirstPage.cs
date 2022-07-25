using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTest.Drivers;

namespace SpecFlowTest.Pages
{
    public class FirstPage
    {
        private IWebDriver _driverHelper;

        public FirstPage(IWebDriver driverHelper) =>_driverHelper = driverHelper;

        public IWebElement logo => _driverHelper.FindElement(By.TagName("time"));

        public void GotoFirstPage() => _driverHelper.Navigate().GoToUrl("http://www.vecka.nu");

        public bool IsWeekLogoDisplayed => logo.Displayed;
    }
}