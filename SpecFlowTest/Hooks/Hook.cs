using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTest.Drivers;
using TechTalk.SpecFlow;

namespace SpecFlowTest.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        private static DriverHelper driverHelper;
        private readonly IObjectContainer container;

        public Hooks(ObjectContainer container)
        {
            this.container = container;
        }


        [BeforeFeature]
        public static void BeforeFeature()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--ignore-ssl-errors=yes");
            options.AddArgument("--ignore-certificate-errors");

            driverHelper = new DriverHelper();
            driverHelper.Driver = new ChromeDriver(options);
            driverHelper.Driver.Manage().Window.Maximize();
            driverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [BeforeScenario]
        public void SetUp()
        {
            container.RegisterInstanceAs<IWebDriver>(driverHelper.Driver, "driver");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            if (driverHelper.Driver == null)
                return;

            driverHelper.Driver.Close();
            driverHelper.Driver.Dispose();
            driverHelper.Driver = null;
        }
    }
}