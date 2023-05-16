namespace PeopleForce.Pages;

public class LoginSelectors
{
    public static readonly string LoginButton = "//span[. = 'Sign in']//parent::button";
    public static readonly string EmailField = "//input[@placeholder = 'Email or phone number']";
    public static readonly string PasswordField = "//input[@placeholder = 'Password']";
}