using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    public class RegisterPathPage
    {
        private readonly IWebDriver _driver;

        public RegisterPathPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this); 
        }

        [FindsBy(How = How.Id, Using = "cphBody_btnOpenNewPlan")]
        public IWebElement NewPlanButton { get; set; }

        
        public void NewPlanSelect()
        {
            
            NewPlanButton.Click();
        }

    }
}

