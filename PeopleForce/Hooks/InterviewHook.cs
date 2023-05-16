using PeopleForce.Methods;

namespace PeopleForce.Hooks;

[Binding]
public class InterviewHook
{
    [BeforeFeature("interview")]
    public static void BeforeFeature(FeatureContext featureContext)
    {
        var navigateMethods = new NavigationMethods();
        navigateMethods.NavigateToCompletedInterviewPage();
    }
}