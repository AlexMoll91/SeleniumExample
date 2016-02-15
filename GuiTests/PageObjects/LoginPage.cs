using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "cphBody_btnCreateNew")]
        public IWebElement RegisterButton { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtUsername")]
        public IWebElement UserIdField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtPassword")]
        public IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnLogIn")]
        public IWebElement LoginButton { get; set; }
        
        public void Login(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            UserIdField.Clear();
            // sending a single quote is not possible with the Chrome Driver, it sends two single quotes!
            UserIdField.SendKeys("admin'--");

            PasswordField.Clear();
            PasswordField.SendKeys("blah");

            LoginButton.Click();
        }

        public void Register(string baseUrl)
        {
            _driver.Navigate().GoToUrl(baseUrl);
            RegisterButton.Click();
        }
    }
}

