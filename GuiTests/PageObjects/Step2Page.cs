using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.PageObjects
    {
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Support;


    namespace Tests.PageObjects
        {
        using System.Threading;
        using Tests = GuiTests.Tests;


        public class Step2Page
            {
            private readonly IWebDriver _driver;

            public Step2Page(IWebDriver driver)
                {
                _driver = driver;
                PageFactory.InitElements(_driver, this);
                }

            [FindsBy(How = How.Id, Using = "cphBody_ddlSalutation")]
            public IWebElement SalutationDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtFirstName")]
            public IWebElement FirstNameField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtFirstName")]
            public IWebElement LastNameField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtSsn")]
            public IWebElement SSNField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthYear")]
            public IWebElement DobYearDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthMonth")]
            public IWebElement DobMonthDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthDay")]
            public IWebElement DobDayDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtAddress1")]
            public IWebElement Address1Field { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtCity")]
            public IWebElement CityField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlStates")]
            public IWebElement StateDropDown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtPrimaryTelephone")]
            public IWebElement PhoneNumberField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_rbCellPhone")]
            public IWebElement CellRadio { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_btnSubmitAccountOwner")]
            public IWebElement NextButton { get; set; }



            
            public void Step2()
            {
                var d = new Data.Data.AccountOwner();
                var SalutationDropdownSelect = new SelectElement(SalutationDropdown);
                var DOBYearDropdownSelect = new SelectElement(DobYearDropdown);
                var DOBMonthDropdownSelect = new SelectElement(DobMonthDropdown);
                var DOBDayDropdownSelect = new SelectElement(DobDayDropdown);
                var StateDropdownSelect = new SelectElement(StateDropDown);

                SalutationDropdownSelect.SelectByText(d.Salutation);
                FirstNameField.SendKeys(d.FirstName);
                LastNameField.SendKeys(d.LastName);
                SSNField.SendKeys(d.SSN);
                DOBYearDropdownSelect.SelectByText(d.Year);
                DOBMonthDropdownSelect.SelectByText(d.Month);
                DOBDayDropdownSelect.SelectByText(d.Day);
                Address1Field.SendKeys(d.Address1);
                CityField.SendKeys(d.City);
                StateDropdownSelect.SelectByText(d.State);
                PhoneNumberField.SendKeys(d.PhoneNum);
                CellRadio.Click();
                NextButton.Click();

            }

            }


        }
    }
