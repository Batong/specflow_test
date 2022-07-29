using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowTest.Pages;
using SpecFlowTest.API;
using SpecFlowTest.Helpers;

namespace SpecFlowTest.Steps;

[Binding]
public class WebAppSteps
{
    private readonly FirstPage _firstPage;
    private readonly ApplicationInterface _api;

    public WebAppSteps(ObjectContainer objectContainer)
    {
        _firstPage = new FirstPage(objectContainer.Resolve<IWebDriver>("driver"));
        _api = new ApplicationInterface();
    }

    [Given(@"I launch the web app url")]
    public void GivenILaunchTheWebAppUrl()
    {
        _firstPage.GotoFirstPage();
    }

    [Then(@"web app should have launched properly")]
    public void ThenWebAppShouldHaveLaunchedProperly()
    {
        Assert.True(_firstPage.IsWeekLogoDisplayed);
        Assert.AreEqual(_firstPage.Logo.Text, Helper.GetWeekOfYear());
    }

    [Given(@"I add the ""(.*)"" URL with endpoint ""(.*)""")]
    public void GivenIAddTheUrlWithEndpoint(string url, string endpoint)
    {
        _api.BaseUrl = url;
        _api.Endpoint = endpoint;
    }

    [When(@"I execute the request")]
    public void WhenIExecuteTheRequest()
    {
        _api.ExecuteRequest();
    }

    [Then(@"the correct ""(.*)"" response is returned")]
    public void ThenTheCorrectResponseIsReturned(string response)
    {
        Assert.AreEqual(response.ToLower(), _api.Response.StatusCode.ToString().ToLower());
    }
}