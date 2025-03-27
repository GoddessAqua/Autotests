using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject;

public class HomePageAutoTests
{
    private IWebDriver _driver;
    private HomePage _homePage;
    private LoginPage _loginPage;
    private SignUpPage _signUpPage;
    private AccountCreatedPage _accountCreatedPage;

    /// <summary>
    /// Driver initial setup
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10);
        
        _homePage = new HomePage(_driver);
        _loginPage = new LoginPage(_driver);
        _signUpPage = new SignUpPage(_driver);
        _accountCreatedPage = new AccountCreatedPage(_driver);
    
        _driver.Navigate().GoToUrl("https://automationexercise.com");
    }

    /// <summary>
    /// Register User on https://automationexercise.com
    /// </summary>
    [Test]
    public void RegisterUser()
    { 
        Assert.That(_driver.Title, Is.EqualTo("Automation Exercise"), "Home page is not visible successfully"); 
        
        _homePage.ClickSignupLoginButton(); 
        
        Assert.That(_loginPage.IsSignUpHeaderVisible(), Is.EqualTo(true) , "Sign up header is not visible successfully");
        
        var timestamp = $"{DateTime.Now:yyyyMMddHHmmss}";
        var username = $"TestUser - {timestamp}";
        var email = $"test{timestamp}@example.com";
        
        _loginPage.SignUp(username, email);
        
        Assert.That( _signUpPage.IsAccountInfoHeaderVisible(), Is.EqualTo(true) , "Account Info header is not visible successfully");
        
        _signUpPage.FillAccountInfo(); 
        
        Assert.That(_accountCreatedPage.IsAccountCreatedVisible(), Is.EqualTo("ACCOUNT CREATED!") , "Account has not been created successfully");
        
        _accountCreatedPage.ClickContinueButton(); 
        
        Assert.That(_homePage.IsUserLoggedIn(), Is.EqualTo($"Logged in as {username}") , "Logged in as username is not visible"); 
        
        _homePage.ClickDeleteAccountButton(); 
        
        Assert.That(_homePage.IsAccountDeleted(), Is.EqualTo("ACCOUNT DELETED!") , "Account has not been deleted successfully");
       
       _homePage.ClickContinueButton();
    }

    [TearDown]
    public void CloseBrowser()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}