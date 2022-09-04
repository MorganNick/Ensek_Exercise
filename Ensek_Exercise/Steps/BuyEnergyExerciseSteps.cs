using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assert = NUnit.Framework.Assert;

namespace Ensek_Exercise.Steps;

[Binding]
public sealed class BuyEnergyExerciseSteps
{
    private readonly ScenarioContext _scenarioContext;

    public BuyEnergyExerciseSteps(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }
    private static readonly IWebDriver Driver = new ChromeDriver();

    [StepDefinition(@"the Buy Energy page is displayed")]
    public void TheBuyEnergyPageIsDisplayed()
    {
        Driver.Url = "https://ensekautomationcandidatetest.azurewebsites.net/Energy/Buy";
        Driver.FindElement(By.XPath("//input[@name='Reset']")).Click();
        bool buyPage = Driver.FindElement(By.XPath("//*[text()='Buy Energy']")).Displayed;
        Assert.True(buyPage);
    }

    [StepDefinition(@"I enter a (.*) to be purchased for a specific (.*)")]
    public void IEnterAToBePurchasedForASpecific(string value, string fuel)
    {
        Driver.FindElement(By.XPath($".//td[text()='{fuel}']/../td[4]/input[@id='energyType_AmountPurchased']")).Clear();
        Driver.FindElement(By.XPath($".//td[text()='{fuel}']/../td[4]/input[@id='energyType_AmountPurchased']")).SendKeys(value);
    }

    [StepDefinition(@"I click the Buy button for the (.*)")]
    public void IClickTheBuyButtonForThe(string fuel)
    {
        Driver.FindElement(By.XPath($".//td[text()='{fuel}']/../td[5]/input[@name='Buy']")).Click();
    }

    [StepDefinition(@"the Sale Confirmed page is displayed with (.*) and (.*)")]
    public void TheSaleConfirmedPageIsDisplayedWithAnd(string value, string fuel)
    {
        bool salesConfirmedPage = Driver.FindElement(By.XPath("//*[text()='Sale Confirmed!']")).Displayed;
        bool saleConfirmed = Driver.FindElement(By.XPath($"//div[@class='well' and contains(text(),'{value} units of {fuel}')]")).Displayed;
        Assert.True(salesConfirmedPage);
        Assert.True(saleConfirmed);
        Driver.FindElement(By.XPath("//*[text()='Buy more »']")).Click();
    }
}