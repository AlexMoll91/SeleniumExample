using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;

    public class AreYouReadyPage
        {
        private readonly IWebDriver _driver;

        public AreYouReadyPage(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_btnCheckout")]
        public IWebElement CheckoutButton { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnBuyPlanForAnotherChild")]
        public IWebElement BuyAnotherButton { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_btnAdd529SavingsPlan")]
        public IWebElement AddSavingsButton { get; set; }






        public void AreYouReady(string Path)
            {
            switch (Path.ToLower())
            {
                case "checkout":
                    CheckoutButton.Click();
                    break;
                case "buyanother":
                    BuyAnotherButton.Click();
                    break;
                case "savings":
                    AddSavingsButton.Click();
                    break;
            }
                

                }
            

        }
    }