using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTest.Drivers;

namespace SpecFlowTest.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        private static DriverHelper s_driverHelper;
        private readonly IObjectContainer _container;

        public Hooks(ObjectContainer container)
        {
            _container = container;
        }


        [BeforeFeature]
        public static void BeforeFeature()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");

            s_driverHelper = new DriverHelper();
            s_driverHelper.Driver = new ChromeDriver(options);
            s_driverHelper.Driver.Manage().Window.Maximize();
            s_driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [BeforeScenario]
        public void SetUp()
        {
            _container.RegisterInstanceAs<IWebDriver>(s_driverHelper.Driver, "driver");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if (s_driverHelper.Driver == null)
                return;

            s_driverHelper.Driver.Close();
            s_driverHelper.Driver.Dispose();
            s_driverHelper.Driver = null;
        }
    }
}