using OpenQA.Selenium;
using PlanA.Web.Core.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Pages;

public class InterviewsPage
{
    public CustomWebElement Filter => new(By.XPath(InterviewsSelectors.Filter));
    public CustomWebElement Apply => new(By.XPath(InterviewsSelectors.Apply));

    public List<string> Headers()
    {
        return Driver.Instance.FindElements(By.XPath(InterviewsSelectors.Headers)).Select(el => el.GetAttribute("href")).ToList();
    }

    public List<string> Dates()
    {
        List<string> dates = new List<string>();
        try
        {
            dates = Driver.Instance.FindElements(By.XPath(InterviewsSelectors.Dates)).Select(el => el.Text).ToList();
        }
        catch (StaleElementReferenceException )
        {
            Driver.Instance.RefreshPage();
            dates = Driver.Instance.FindElements(By.XPath(InterviewsSelectors.Dates)).Select(el => el.Text).ToList();
        }

        return dates;
    }
}