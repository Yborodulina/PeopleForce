namespace PeopleForce.Pages;

public class InterviewsSelectors
{
    public static readonly string Calendar = "//input[contains(@class, 'control') and contains(@class,'daterangepicker')]//ancestor::div[@data-controller]";
    public static readonly string Filter = "//span[. = 'Filter']//parent::button";
    public static readonly string Apply = "//button[. = 'Apply']";
    public static readonly string Headers = "//h4//a";
    public static readonly string Dates = "//div[@class = 'card-body']//strong";
}