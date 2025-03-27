using OpenQA.Selenium;

namespace TestProject;

public class LoginPage(IWebDriver driver)
{
    public bool IsSignUpHeaderVisible()
    {
        return driver.FindElement(By.XPath("//h2[contains(text(), 'New User Signup!')]")).Displayed; // anchor with inner text containing 'New User Signup!'
    }

    public void SignUp(string username, string email)
    {
        var nameInput = driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
        var emailInput = driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
        
        nameInput.SendKeys(username);
        emailInput.SendKeys(email);
        
        var signUpButton = driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));
        signUpButton.Click();
    }
}