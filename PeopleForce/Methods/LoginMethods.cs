using OpenQA.Selenium;
using PeopleForce.Pages;
using PlanA.Web.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Methods;

public class LoginMethods
{
    private readonly LoginPage _loginPage;

    public LoginMethods()
    {
        _loginPage = new LoginPage();
    }

    public void Login()
    {
        _loginPage.EmailField.Element.SendKeys(TestConfig.UserEmail);
        _loginPage.PasswordField.Element.SendKeys(TestConfig.UserPassword);
        Driver.Instance.CriticalWait();
        _loginPage.PasswordField.Element.SendKeys(Keys.Enter);
    }
}