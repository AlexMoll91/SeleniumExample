using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using System.Threading;
    using OpenQA.Selenium.Support.UI;

    public class Step6Page
        {
        private readonly IWebDriver _driver;

        public Step6Page(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_rbResidencyOnline")]
        public IWebElement ResidencyOnlineRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbResidencyMailIn")]
        public IWebElement ResidencyMailRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_ddlParentGuardian")]
        public IWebElement ParentDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtFirstName")]
        public IWebElement FirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtLastName")]
        public IWebElement LastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitResidency")]
        public IWebElement NextButton { get; set; }






        public void SubmitResidency(int OptionNum)
            {
            if (OptionNum == 1)
            {
               ResidencyOnlineRadio.Click(); 
            }
            else
            {
                Thread.Sleep(2000);
                ResidencyMailRadio.Click();
            }
            var ParentDropdownSelect = new SelectElement(ParentDropdown);
            ParentDropdownSelect.SelectByText("Yes");
            FirstNameField.SendKeys("Kyle");
            LastNameField.SendKeys("Crabtree");
            NextButton.Click();
            }

        }
    }