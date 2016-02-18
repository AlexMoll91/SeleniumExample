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
        using OpenQA.Selenium.Interactions;
        using Tests = GuiTests.Tests;


        public class Step3Page
            {
            private readonly IWebDriver _driver;

            public Step3Page(IWebDriver driver)
                {
                _driver = driver;
                PageFactory.InitElements(_driver, this);
                }

            

            [FindsBy(How = How.Id, Using = "cphBody_txtFirstName")]
            public IWebElement FirstNameField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtLastName")]
            public IWebElement LastNameField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtSsn")]
            public IWebElement SSNField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthYear")]
            public IWebElement DobYearDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthMonth")]
            public IWebElement DobMonthDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlDateOfBirthDay")]
            public IWebElement DobDayDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlAgeGrade")]
            public IWebElement AgeGradeDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtAddress1")]
            public IWebElement Address1Field { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtCity")]
            public IWebElement CityField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlStates")]
            public IWebElement StateDropDown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtZip")]
            public IWebElement ZipCodeField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_btnSubmitBeneficiary")]
            public IWebElement NextButton { get; set; }




            public void Step3()
                {
                var d = new Data.Data.Beneficiary();
                
                var DOBYearDropdownSelect = new SelectElement(DobYearDropdown);
                var DOBMonthDropdownSelect = new SelectElement(DobMonthDropdown);
                var DOBDayDropdownSelect = new SelectElement(DobDayDropdown);
                var StateDropdownSelect = new SelectElement(StateDropDown);
                
                
                FirstNameField.SendKeys(d.FirstName);
                LastNameField.SendKeys(d.LastName);
                SSNField.SendKeys(d.SSN);
                DOBYearDropdownSelect.SelectByText(d.Year);
                DOBMonthDropdownSelect.SelectByText(d.Month);
                DOBDayDropdownSelect.SelectByText(d.Day);
                SSNField.Click();
                Actions builder = new Actions(_driver);
                builder.SendKeys(Keys.Tab).Perform();
                var AgeGradeDropdownSelect = new SelectElement(AgeGradeDropdown);
                AgeGradeDropdownSelect.SelectByIndex(d.AgeGrade);
                Address1Field.SendKeys(d.Address1);
                CityField.SendKeys(d.City);
                StateDropdownSelect.SelectByText(d.State);
                ZipCodeField.SendKeys(d.Zip);
                NextButton.Click();

                }

            }


        }
    }
