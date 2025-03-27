using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestProject;

public class SignUpPage(IWebDriver driver)
{
    public bool IsAccountInfoHeaderVisible()
    {
        return driver.FindElement(By.XPath("//h2[contains(., 'Enter Account Information')]")).Displayed;
    }

    public void FillAccountInfo()
    {
        var accountInformationTitle = driver.FindElement(By.XPath("//input[@id='id_gender2']"));
        accountInformationTitle.Click();
        
        var accountInformationPassword = driver.FindElement(By.XPath("//input[@id='password']"));
        accountInformationPassword.SendKeys("Test1234");

        var birthDateDaysDropdown = driver.FindElement(By.XPath("//select[@id='days']"));
        var select = new SelectElement(birthDateDaysDropdown);
        select.SelectByValue("15");
        
        var birthDateMonthDropdown = driver.FindElement(By.XPath("//select[@id='months']"));
        select = new SelectElement(birthDateMonthDropdown);
        select.SelectByValue("5");
        
        var birthDateYearDropdown = driver.FindElement(By.XPath("//select[@id='years']"));
        select = new SelectElement(birthDateYearDropdown);
        select.SelectByValue("1990");
        
        var newsletterCheckbox  = driver.FindElement(By.XPath("//input[@id='newsletter']"));
        newsletterCheckbox.Click();
        
        var specialOffersCheckbox   = driver.FindElement(By.XPath("//input[@id='optin']"));
        specialOffersCheckbox.Click();
        
        var accountInformationFirstName = driver.FindElement(By.XPath("//input[@data-qa='first_name']"));
        var accountInformationLastName = driver.FindElement(By.XPath("//input[@data-qa='last_name']"));
        var accountInformationCompany = driver.FindElement(By.XPath("//input[@data-qa='company']"));
        var accountInformationAddress = driver.FindElement(By.XPath("//input[@data-qa='address']"));
        var accountInformationAddress2 = driver.FindElement(By.XPath("//input[@data-qa='address2']"));
        var accountInformationCountryDropdown = driver.FindElement(By.XPath("//select[@id='country']"));
        var accountInformationState = driver.FindElement(By.XPath("//input[@data-qa='state']"));
        var accountInformationCity = driver.FindElement(By.XPath("//input[@data-qa='city']"));
        var accountInformationZipCode = driver.FindElement(By.XPath("//input[@data-qa='zipcode']"));
        var accountInformationMobileNumber = driver.FindElement(By.XPath("//input[@data-qa='mobile_number']"));
        
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

        var createAccountButton = driver.FindElement(By.XPath("//button[@data-qa='create-account']"));
        createAccountButton.Click();
    }
}