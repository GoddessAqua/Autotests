using OpenQA.Selenium;

namespace TestProject;

public class HomePage(IWebDriver driver)
{
    public void ClickSignupLoginButton()
    {
        var loginButton = driver.FindElement(By.XPath("//a[@href='/login']")); // anchor with target link 'url'
        loginButton.Click();
    }

    public string IsUserLoggedIn()
    {
       return driver.FindElement(By.XPath("//li[contains(., ' Logged in as ')]")).Text;
    }
    
    public void ClickDeleteAccountButton()
    {
        var deleteAccountButton = driver.FindElement(By.XPath("//a[contains(@href,'/delete_account')]"));
        deleteAccountButton.Click();
    }
    
    public string IsAccountDeleted()
    {
        return driver.FindElement(By.XPath("//h2[@data-qa='account-deleted']")).Text;
    }
    
    public void ClickContinueButton()
    {
        var continueButton = driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));
        continueButton.Click();
    }
}