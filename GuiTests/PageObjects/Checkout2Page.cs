using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;

    public class Checkout2Page
        {
        private readonly IWebDriver _driver;

        public Checkout2Page(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_chkPrepaidNewAgreement")]
        public IWebElement PrepaidAgreementCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitCheckout")]
        public IWebElement SubmitApplicationButton { get; set; }








        public void Checkout2(bool savingsYN, bool prepaidYN)
            {
            if (prepaidYN)
            {
                PrepaidAgreementCheckbox.Click();
            }
            if (savingsYN)
            {
                
            }
            SubmitApplicationButton.Click();
            }

        }
    }