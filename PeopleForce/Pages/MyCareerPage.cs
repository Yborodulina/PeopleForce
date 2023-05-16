using OpenQA.Selenium;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Pages;

public class MyCareerPage
{
    public IWebElement NavigationTabs(string tab)
    {
        Driver.Instance.WaitElementToBeClickable(By.XPath($"//a[contains(@href, '{tab}')]"), 30);
        return Driver.Instance.FindElement(By.XPath($"//a[contains(@href, '{tab}')]"));
    }
}