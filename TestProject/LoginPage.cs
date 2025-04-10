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
    
    public bool IsLoginHeaderVisible()
    {
        return driver.FindElement(By.XPath("//h2[text() = 'Login to your account']")).Displayed; // anchor with inner text containing 'New User Signup!'
    }
    
    public void Login(string email, string password)
    {
        var emailInput = driver.FindElement(By.XPath("//input[@data-qa = 'login-email']"));
        var passwordInput = driver.FindElement(By.XPath("//input[@data-qa='login-password']"));
        
        emailInput.SendKeys(email);
        passwordInput.SendKeys(password);
        
        var loginButton = driver.FindElement(By.XPath("//button[@data-qa='login-button']"));
        loginButton.Click();
    }
    
    public bool IsIncorrectPasswordErrorVisible()
    {
        return driver.FindElement(By.XPath("//p[contains(text(), 'Your email or password is incorrect!')]")).Displayed; // anchor with inner text containing 'New User Signup!'
    }
}