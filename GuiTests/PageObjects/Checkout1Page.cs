using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;

    public class Checkout1Page
        {
        private readonly IWebDriver _driver;

        public Checkout1Page(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_rbPayByAch")]
        public IWebElement ACHRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbPayByCC")]
        public IWebElement CCRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbPayByMail")]
        public IWebElement MailInRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitCheckout")]
        public IWebElement NextButton { get; set; }






        public void Checkout1(string paymentType)
            {
            switch (paymentType.ToLower())
            {
                case "ach":
                    break;
                case "cc":
                    break;
                case "mailin":
                    MailInRadio.Click();
                    break;
            }
            NextButton.Click();
            }

        }
    }