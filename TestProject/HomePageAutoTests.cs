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
    
        var timestamp = $"{DateTime.Now:yyyyMMddHHmmss}";
        var username = $"TestUser - {timestamp}";
        
        nameInput.SendKeys(username);
        emailInput.SendKeys($"test{timestamp}@example.com");
    
        // 7. Click 'Signup' button
        var signUpButton = _driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));
        signUpButton.Click();
    
        // 8. Verify that 'ENTER ACCOUNT INFORMATION' is visible
        var accountInfoHeader = _driver.FindElement(By.XPath("//h2[contains(., 'Enter Account Information')]"));
        accountInfoHeader.Displayed.Should().BeTrue();
        
        // 9. Fill details: Title, Name, Email, Password, Date of birth
        var accountInformationTitle = _driver.FindElement(By.XPath("//input[@id='id_gender2']"));
        accountInformationTitle.Click();
        
        var accountInformationPassword = _driver.FindElement(By.XPath("//input[@id='password']"));
        accountInformationPassword.SendKeys("Test1234");
        
        var birthDateDaysDropdown = _driver.FindElement(By.XPath("//select[@id='days']"));
        birthDateDaysDropdown.Click();
        birthDateDaysDropdown.FindElement(By.XPath(".//option[@value='15']")).Click();
        
        var birthDateMonthDropdown = _driver.FindElement(By.XPath("//select[@id='months']"));
        birthDateMonthDropdown.Click();
        birthDateMonthDropdown.FindElement(By.XPath(".//option[@value='5']")).Click();
        
        var birthDateYearDropdown = _driver.FindElement(By.XPath("//select[@id='years']"));
        birthDateYearDropdown.Click();
        birthDateYearDropdown.FindElement(By.XPath(".//option[@value='1990']")).Click();
        
        // 10. Select checkbox 'Sign up for our newsletter!'
        var newsletterCheckbox  = _driver.FindElement(By.XPath("//input[@id='newsletter']"));
        newsletterCheckbox.Click();
        
        // 11. Select checkbox 'Receive special offers from our partners!'
        var specialOffersCheckbox   = _driver.FindElement(By.XPath("//input[@id='optin']"));
        specialOffersCheckbox.Click();
        
        // 12. Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
        
        var accountInformationFirstName = _driver.FindElement(By.XPath("//input[@data-qa='first_name']"));
        var accountInformationLastName = _driver.FindElement(By.XPath("//input[@data-qa='last_name']"));
        var accountInformationCompany = _driver.FindElement(By.XPath("//input[@data-qa='company']"));
        var accountInformationAddress = _driver.FindElement(By.XPath("//input[@data-qa='address']"));
        var accountInformationAddress2 = _driver.FindElement(By.XPath("//input[@data-qa='address2']"));
        var accountInformationCountryDropdown = _driver.FindElement(By.XPath("//select[@id='country']"));
        var accountInformationState = _driver.FindElement(By.XPath("//input[@data-qa='state']"));
        var accountInformationCity = _driver.FindElement(By.XPath("//input[@data-qa='city']"));
        var accountInformationZipCode = _driver.FindElement(By.XPath("//input[@data-qa='zipcode']"));
        var accountInformationMobileNumber = _driver.FindElement(By.XPath("//input[@data-qa='mobile_number']"));
        
        accountInformationFirstName.SendKeys("Test");
        accountInformationLastName.SendKeys("User");
        accountInformationCompany.SendKeys("TestCompany");
        accountInformationAddress.SendKeys("123 Test Street");
        accountInformationAddress2.SendKeys("TApt 4B");
        
        accountInformationCountryDropdown.Click();
        accountInformationCountryDropdown.FindElement(By.XPath(".//option[contains(text(),'United States')]")).Click();
        
        accountInformationState.SendKeys("California");
        accountInformationCity.SendKeys("Los Angeles");
        accountInformationZipCode.SendKeys("90001");
        accountInformationMobileNumber.SendKeys("1234567890");

        // 13. Click 'Create Account button'
        var createAccountButton = _driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
        createAccountButton.Click();
        
        // 14. Verify that 'ACCOUNT CREATED!' is visible
        var accountCreatedHeader = _driver.FindElement(By.XPath("//h2[@data-qa='account-created']"));
        accountCreatedHeader.Text.Should().Be("ACCOUNT CREATED!");
        
        // 15. Click 'Continue' button
        var continueButton = _driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));
        continueButton.Click();
        
        // 16. Verify that 'Logged in as username' is visible
        var loggedInText = _driver.FindElement(By.XPath("//li[10]/a"));
        loggedInText.Text.Should().Be($"Logged in as {username}");
        
        // 17. Click 'Delete Account' button
        var deleteAccountButton = _driver.FindElement(By.XPath("//a[contains(@href,'/delete_account')]"));
        deleteAccountButton.Click();

        // 18. Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
        var accountDeletedHeader = _driver.FindElement(By.XPath("//h2[@data-qa='account-deleted']"));
        accountDeletedHeader.Text.Should().Be("ACCOUNT DELETED!");
        
        continueButton = _driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));
        continueButton.Click();
    }

    [TearDown]
    public void CloseBrowser()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}