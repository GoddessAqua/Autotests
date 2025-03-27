using OpenQA.Selenium;

namespace TestProject;

public class AccountCreatedPage(IWebDriver driver)
{
    public string IsAccountCreatedVisible()
    {
        return driver.FindElement(By.XPath("//h2[@data-qa='account-created']")).Text;
    }

    public void ClickContinueButton()
    {
        var continueButton = driver.FindElement(By.XPath("//a[@data-qa='continue-button']"));
        continueButton.Click();
    }
}