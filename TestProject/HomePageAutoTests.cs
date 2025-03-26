using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject;

public class HomePageAutoTests
{
    private IWebDriver _driver;

    /// <summary>
    /// Driver initial setup
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver(); // 1.Launch browser
    
        // Driver additional setup
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10);
    
        _driver.Navigate().GoToUrl("https://automationexercise.com"); // 2. Navigate to url 'https://automationexercise.com'
    
        _driver.Title.Should().Be("Automation Exercise"); // 3. Verify that home page is visible successfully (by unique title)
    }

    /// <summary>
    /// Register User on https://automationexercise.com
    /// </summary>
    [Test]
    public void RegisterUser()
    {
        // 4. Click on 'Signup / Login' button
        var loginButton = _driver.FindElement(By.XPath("//a[@href='/login']")); // anchor with target link 'url'
        loginButton.Click();
    
        // 5. Verify 'New User Signup!' is visible
        var signUpHeader = _driver.FindElement(By.XPath("//h2[contains(text(), 'New User Signup!')]")); // anchor with inner text containing 'New User Signup!'
        signUpHeader.Displayed.Should().BeTrue();
    
        // 6. Enter name and email address
        var nameInput = _driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
        var emailInput = _driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
    
        nameInput.SendKeys("VR");
        emailInput.SendKeys("vrcsad@gmail.com");
    
        // 7. Click 'Signup' button
        var signUpButton = _driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));
        signUpButton.Click();
    
        // 8. Verify that 'ENTER ACCOUNT INFORMATION' is visible
        var enterAccountInformation = _driver.FindElement(By.XPath("//h2[contains(., 'Enter Account Information')]"));
        enterAccountInformation.Displayed.Should().BeTrue();
    }

    [TearDown]
    public void CloseBrowser()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}