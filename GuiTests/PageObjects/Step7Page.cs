using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;

    public class Step7Page
        {
        private readonly IWebDriver _driver;

        public Step7Page(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_rbMainPrepaidMailIn")]
        public IWebElement PrepaidMailInRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbMainPrepaidAutomaticWithdrawal")]
        public IWebElement PrepaidAutomaticWithdrawalRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitHowToPay")]
        public IWebElement NextButton { get; set; }






        public void HowToPay(bool AutomaticYN)
            {
            if (AutomaticYN)
                {
                
                }
            else
                {
                    PrepaidMailInRadio.Click();
                }
            
            NextButton.Click();
            }

        }
    }