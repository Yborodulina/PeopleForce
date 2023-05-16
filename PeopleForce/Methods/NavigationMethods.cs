using PeopleForce.Enums;
using PeopleForce.Pages;
using PlanA.Web.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Methods;

public class NavigationMethods
{
    private readonly HomePage _homePage;
    private readonly MyCareerPage _myCareerPage;

    public NavigationMethods()
    {
        _homePage = new HomePage();
        _myCareerPage = new MyCareerPage();
    }

    public void NavigateToCompletedInterviewPage()
    {
        Driver.Instance.NavigateTo($"{TestConfig.BaseUrl}/my/recruitment/interviews/completed");
    }
}