using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;
    using Structura.GuiTests.Data;

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

        [FindsBy(How = How.Id, Using = "cphBody_chkFourYearFloridaCollegePlan")]
        public IWebElement FourYearCollegeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkTwoYearFloridaCollegePlan")]
        public IWebElement TwoYearCollegeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkFourYearFloridaUniversityPlan")]
        public IWebElement FourYearUniversityCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkOneYearFloridaUniversityPlan1")]
        public IWebElement OneYearUniversity1CheckBox1 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkOneYearFloridaUniversityPlan2")]
        public IWebElement OneYearUniversity1CheckBox2 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkOneYearFloridaUniversityPlan3")]
        public IWebElement OneYearUniversity1CheckBox3 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkOneYearFloridaUniversityPlan4")]
        public IWebElement OneYearUniversity1CheckBox4 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chkTwoPlusTwoFloridaPlan")]
        public IWebElement TwoPlusTwoCheckbox { get; set; }

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

        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitHowToPay")]
        public IWebElement NextButton { get; set; }

        

        


        public void HowToPay(string planType1, string planType2, int oneyearAmount, string paymentPlan, bool AutomaticYN)
            {
            if (AutomaticYN)
                {
                var d = new Data.ACHInfo();
                PrepaidAutomaticWithdrawalRadio.Click();
                    if((planType1 + planType2 + oneyearAmount).ToLower().Contains("twoyear"))
                        {
                        TwoYearCollegeCheckbox.Click();
                        }
                    if ((planType1 + planType2 + oneyearAmount).ToLower().Contains("fouryearcollege"))
                        {
                        FourYearCollegeCheckbox.Click();
                        }
                    if ((planType1 + planType2 + oneyearAmount).ToLower().Contains("fouryearuniversity"))
                        {
                        FourYearUniversityCheckbox.Click();
                        }
                    if ((planType1 + planType2 + oneyearAmount).ToLower().Contains("twoplustwo"))
                        {
                        TwoPlusTwoCheckbox.Click();
                        }
                    switch (oneyearAmount)
                    {
                        case 0:
                            break;
                        case 1:
                            OneYearUniversity1CheckBox1.Click();
                            break;
                        case 2:
                            OneYearUniversity1CheckBox1.Click();
                            OneYearUniversity1CheckBox2.Click();
                            break;
                        case 3:
                            OneYearUniversity1CheckBox1.Click();
                            OneYearUniversity1CheckBox2.Click();
                            OneYearUniversity1CheckBox3.Click();
                            break;
                        case 4:
                            OneYearUniversity1CheckBox1.Click();
                            OneYearUniversity1CheckBox2.Click();
                            OneYearUniversity1CheckBox3.Click();
                            OneYearUniversity1CheckBox4.Click();
                            break;
                    }
                FinancialInstitutionNameField.SendKeys(d.BankName);
                FinancialInstitutionAccountNumField.SendKeys(d.BankAccountNum);
                FinancialInstitutionRoutingField.SendKeys(d.BankRouting);
                var FinancialInstitutionTypeDropdownSelect = new SelectElement(FinancialInstitutionAccountTypeDropdown);
                FinancialInstitutionTypeDropdownSelect.SelectByValue(d.BankAccountType);
                PrepaidTOSCheckbox.Click();
                }
            else
                {
                    PrepaidMailInRadio.Click();
                }
            
            NextButton.Click();
            }

        }
    }