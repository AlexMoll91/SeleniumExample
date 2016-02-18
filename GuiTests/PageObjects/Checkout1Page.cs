using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using Structura.GuiTests.Data;

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

        [FindsBy(How = How.Id, Using = "cphBody_txtBankName")]
        public IWebElement FinancialInstitutionNameField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtBankRoutingNumber")]
        public IWebElement FinancialInstitutionRoutingField { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_txtBankAccountNumber")]
        public IWebElement FinancialInstitutionAccountNumField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_ddlBankAccountType")]
        public IWebElement FinancialInstitutionAccountTypeDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkAgreePrepaid")]
        public IWebElement PrepaidTOSCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkAgreeCreditCard")]
        public IWebElement PrepaidCCTOSCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtCardHoldersFirstName")]
        public IWebElement CCFirstNameField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtCardholdersLastName")]
        public IWebElement CCLastNameField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtCreditCardNumber")]
        public IWebElement CCCardNumField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtSecurityCode")]
        public IWebElement CCCVCField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_ddlMonth")]
        public IWebElement ExpirationMonthDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_ddlYear")]
        public IWebElement ExpirationYearDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtZip")]
        public IWebElement CCZipField { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txtPromoCode")]
        public IWebElement PromoCodeField { get; set; }



            

        public void Checkout1(string paymentType)
            {
            switch (paymentType.ToLower())
            {
                case "ach":
                    var d = new Data.ACHInfo();
                    ACHRadio.Click();
                    PromoCodeField.Click();
                    FinancialInstitutionNameField.SendKeys(d.BankName);
                    FinancialInstitutionAccountNumField.SendKeys(d.BankAccountNum);
                    FinancialInstitutionRoutingField.SendKeys(d.BankRouting);
                    var FinancialInstitutionTypeDropdownSelect = new SelectElement(FinancialInstitutionAccountTypeDropdown);
                    FinancialInstitutionTypeDropdownSelect.SelectByValue(d.BankAccountType);
                    PrepaidTOSCheckbox.Click();
                    break;
                case "cc":
                    var dcc = new Data.CCInfo();
                    CCRadio.Click();
                    PromoCodeField.Click();
                    FluentAssertions.AssertionExtensions.Should(CCFirstNameField.Displayed);
                    CCFirstNameField.SendKeys(dcc.FirstName);
                    CCLastNameField.SendKeys(dcc.LastName);
                    CCCardNumField.SendKeys(dcc.CCNum);
                    CCCVCField.SendKeys(dcc.CCCVC);
                    var CCExpMonthDropdown = new SelectElement(ExpirationMonthDropdown);
                    CCExpMonthDropdown.SelectByValue(dcc.ExpMonth);
                    var CCExpYearDropdown = new SelectElement(ExpirationYearDropdown);
                    CCExpYearDropdown.SelectByValue(dcc.ExpYear);
                    CCZipField.SendKeys(dcc.ZipCode);
                    PrepaidCCTOSCheckbox.Click();
                    Console.WriteLine("[CC #: "+CCCardNumField+"]");
                    break;
                case "mailin":
                    MailInRadio.Click();
                    break;
            }
            NextButton.Click();
            }

        }
    }