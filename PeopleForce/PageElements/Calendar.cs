using OpenQA.Selenium;
using PeopleForce.Enums;
using PlanA.Web.Core.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;

namespace PeopleForce.PageElements;

public class Calendar
{
    private By Locator { get; }

    public Calendar(By locator)
    {
        Locator = locator;
    }

    public IWebElement CalendarElement => Driver.Instance.FindElement(Locator);

    private readonly CustomWebElement _startMonthTitle = new CustomWebElement(By.XPath(CalendarSelectors.StartMonthTitle));
    private readonly CustomWebElement _endMonthTitle = new CustomWebElement(By.XPath(CalendarSelectors.EndMonthTitle));

    public void SelectStartDate(DateTime startDate)
    {
        var date = startDate.ToString("d MMMM yyyy").Split(" ");
        var year = date[2];
        var month = date[1];
        var day = date[0];

        var monthYear = _startMonthTitle.Element.Text.Split(" ");
        var monthSelected = monthYear[0];
        var yearSelected = monthYear[1];

        if (yearSelected != year)
        {
            SelectStartYear(year);
        }

        if (monthSelected != month)
        {
            SelectStartMount(month);
        }

        Driver.Instance.CriticalWait();

        GetStartDay(day).Click();
    }

    public void SelectEndDate(DateTime endDate)
    {
        var date = endDate.ToString("d MMMM yyyy").Split(" ");
        var year = date[2];
        var month = date[1];
        var day = date[0];

        var monthYear = _endMonthTitle.Element.Text.Split(" ");
        var monthSelected = monthYear[0];
        var yearSelected = monthYear[1];

        if (yearSelected != year)
        {
            SelectEndYear(year);
        }

        if (monthSelected != month)
        {
            SelectEndMount(month);
        }

        Driver.Instance.CriticalWait();
        GetEndDay(day).Click();
    }

    private IWebElement GetEndDay(string day)
    {
        var days = Driver.Instance.FindElements(By.XPath($"//div[contains(@class, 'right-calendar')]//span[.={day}]")).ToList();
        return days.FirstOrDefault(d => d.GetAttribute("class").Contains("other-month") != true);
    }

    private void SelectStartYear(string year)
    {
        _startMonthTitle.Element.Click();
        _startMonthTitle.Element.Click();
        Driver.Instance.FindElement(By.XPath($"//div[contains(@class, 'left-calendar')]//span[.='{year}']")).Click();
    }

    private IWebElement? GetStartDay(string day)
    {
        var days = Driver.Instance.FindElements(By.XPath($"//div[contains(@class, 'left-calendar')]//span[.={day}]")).ToList();
        return days.FirstOrDefault(d => d.GetAttribute("class").Contains("other-month") != true);
    }

    private void SelectStartMount(string monthExpected)
    {
        _startMonthTitle.Element.Click();
        Driver.Instance.FindElement(By.XPath($"//div[contains(@class, 'left-calendar')]//span[.='{monthExpected.Substring(0, 3)}']")).Click();
    }

    private void SelectEndYear(string year)
    {
        _endMonthTitle.Element.Click();
        _endMonthTitle.Element.Click();
        Driver.Instance.FindElement(By.XPath($"//div[contains(@class, 'right-calendar')]//span[.='{year}']")).Click();
    }

    private IWebElement? GetEndtDay(string day)
    {
        var days = Driver.Instance.FindElements(By.XPath($"//div[contains(@class, 'right-calendar')]//span[.={day}]")).ToList();
        return days.FirstOrDefault(d => d.GetAttribute("class").Contains("other-month") != true);
    }

    private void SelectEndMount(string monthExpected)
    {
        _endMonthTitle.Element.Click();
        Driver.Instance.FindElement(By.XPath($"//div[contains(@class, 'right-calendar')]//span[.='{monthExpected.Substring(0, 3)}']")).Click();
    }
}