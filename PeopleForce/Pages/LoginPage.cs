using OpenQA.Selenium;
using PlanA.Web.Core.Core;

namespace PeopleForce.Pages;

public class LoginPage
{
    public CustomWebElement LoginButton => new(By.XPath(LoginSelectors.LoginButton));
    public CustomWebElement EmailField => new(By.XPath(LoginSelectors.EmailField));
    public CustomWebElement PasswordField => new(By.XPath(LoginSelectors.PasswordField));
}