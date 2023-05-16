using System.ComponentModel;

namespace PeopleForce.Enums;

public enum MyCareerNavigationTabs : byte
{
    [Description("interviews")] Interviews,
    [Description("completed")] CompletedInterviews
}