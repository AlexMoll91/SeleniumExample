using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
        using System;
        using OpenQA.Selenium.Support.UI;

        public class Step2DeliveryPage
        {
        private readonly IWebDriver _driver;

        public Step2DeliveryPage(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_ddlStatements")]
        public IWebElement StatementDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_ddlTaxForms")]
        public IWebElement TaxDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitEDelivery")]
        public IWebElement NextButton { get; set; }


        


        public void Step2DeliveryOptions()
            {
            var StatementDropdownSelect = new SelectElement(StatementDropdown);
            var TaxDropdownSelect = new SelectElement(TaxDropdown);
            StatementDropdownSelect.SelectByIndex(new Random().Next(1,2));
            TaxDropdownSelect.SelectByIndex(new Random().Next(1, 2));
            NextButton.Click();
            }

        }
    }