using OpenQA.Selenium;
using PlanA.Web.Core.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Pages;

public class HomePage
{
    public IWebElement LeftSideMenuOption(string option)
    {
        Driver.Instance.WaitElementToBeClickable(By.XPath($"//li[@data-bs-original-title= '{option}']"), 30);
        return Driver.Instance.FindElement(By.XPath($"//li[@data-bs-original-title= '{option}']"));
    }
}