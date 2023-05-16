using NUnit.Framework;
using PeopleForce.Methods;
using PeopleForce.Models;

namespace PeopleForce.Steps;

[Binding]
public class InterviewStepsDefinition
{
    private readonly InterviewMethods _interview;
    private readonly GoogleSheetsMethods _googleSheetsMethods;
    private readonly ScenarioContext _scenarioContext;

    public InterviewStepsDefinition(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
        _interview = new InterviewMethods();
        _googleSheetsMethods = new GoogleSheetsMethods();
    }

    [Given(@"user filter interview from ""(.*)"" to ""(.*)""")]
    public void GivenUserFilterInterviewFromTo(string startDate, string endDate)
    {
        _interview.Filter(startDate, endDate);
    }

    [Given(@"user save interviews data to the ""(.*)""")]
    public void GivenUserSaveInterviewsDataToThe(string key)
    {
        _scenarioContext.Add(key, _interview.SaveData());
    }

    [Then(@"user write data ""(.*)"" to the google sheet ""(.*)""")]
    public void ThenUserWriteDataToTheGoogleSheet(string key, string spreadsheetId)
    {
        _googleSheetsMethods.Write(spreadsheetId, (List<InterviewDataModel>)_scenarioContext[key]);
    }
}