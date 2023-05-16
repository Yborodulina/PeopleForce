using OpenQA.Selenium;
using PeopleForce.Models;
using PeopleForce.PageElements;
using PeopleForce.Pages;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.Methods;

public class InterviewMethods
{
    private readonly InterviewsPage _interviewsPage;

    public InterviewMethods()
    {
        _interviewsPage = new InterviewsPage();
    }

    public void Filter(string startDate, string endDate)
    {
        Driver.Instance.WaitElementToBeClickable(By.XPath(InterviewsSelectors.Calendar), 30);
        var calendar = new Calendar(By.XPath(InterviewsSelectors.Calendar));
        calendar.CalendarElement.Click();
        calendar.SelectStartDate(DateTime.Parse(startDate));
        calendar.SelectEndDate(DateTime.Parse(endDate));
        _interviewsPage.Apply.Element.Click();
        _interviewsPage.Filter.Element.Click();
        Driver.Instance.CriticalWait();
    }

    public List<InterviewDataModel> SaveData()
    {
        var interviews = new List<InterviewDataModel>();
        var dates = _interviewsPage.Dates();
        var headers = _interviewsPage.Headers();
        for (var i = 0; i < dates.Count; i++)
        {
            interviews.Add(new InterviewDataModel()
            {
                Date = dates[i],
                Link = headers[i],
                Author = "Yana Borodulina"
            });
        }

        return interviews;
    }
}

   