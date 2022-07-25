using System.Globalization;
using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowTest.Pages;
using SpecFlowTest.API;
using SpecFlowTest.Drivers;
using SpecFlowTest.Helpers;
using TechTalk.SpecFlow.Infrastructure;

namespace SpecFlowTest;

[Binding]
public class WebAppSteps : Helper
{
    private readonly FirstPage firstPage;
    private readonly ApplicationInterface api;

    public WebAppSteps(ObjectContainer objectContainer) // use it as ctor parameter
    {
        firstPage = new FirstPage(objectContainer.Resolve<IWebDriver>("driver"));
        api = new ApplicationInterface();
    }

    [Given(@"I launch the web app url")]
    public void WhenILaunchTheWebAppUrl()
    {
        firstPage.GotoFirstPage();
    }

    [Then(@"web app should have launched properly")]
    public void ThenWebAppShouldHaveLaunchedProperly()
    {
        Assert.True(firstPage.IsWeekLogoDisplayed);
        Assert.AreEqual(firstPage.logo.Text, Helper.getWeekOfYear());
    }
    
    [Given(@"I add the ""(.*)"" URL with endpoint ""(.*)""")]
    public void GivenIAddTheUrlWithEndpoint(string url, string endpoint)
    {
        api.BaseUrl = url;
        api.Endpoint = endpoint;
    }

    [When(@"I execute the request")]
    public void WhenIExecuteTheRequest()
    {
        api.ExecuteRequest();
    }

    [Then(@"the correct ""(.*)"" response is returned")]
    public void ThenTheCorrectResponseIsReturned(string response)
    {
        Assert.AreEqual(response.ToLower(), api.Response.StatusCode.ToString().ToLower());
    }
}