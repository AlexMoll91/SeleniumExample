using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
    {
    using System;
    using OpenQA.Selenium.Support.UI;

    public class Step4Page
        {
        private readonly IWebDriver _driver;

        public Step4Page(IWebDriver driver)
            {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
            }

        [FindsBy(How = How.Id, Using = "cphBody_chk2YearFloridaCollegePlan")]
        public IWebElement TwoYearCheckbox { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_chk1YearUniversityPlan")]
        public IWebElement OneYearCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txt1YearUniversityPlanQuantity")]
        public IWebElement OneYearAmount { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_chk4YearFloridaCollegePlan")]
        public IWebElement FourYearCollegeCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chk22FloridaPlan")]
        public IWebElement TwoPlusTwoCheckbox { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_chk4YearFloridaUniversityPlan")]
        public IWebElement FourYearUniversityCheckBox { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_chkSavingsPlan")]
        public IWebElement SavingsCheckbox { get; set; }

        
        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitPlanSelection")]
        public IWebElement NextButton { get; set; }


        public void Step4SelectPlan(string planType1, string planType2, bool SavingsYN, int OneYearYearAmount)
        {
            if (planType1 == "TwoYearCollege" || planType2 == "TwoYearCollege")
            {
                TwoYearCheckbox.Click();
            }
            if (planType1 == "OneYearUniversity" || planType2 == "OneYearUniversity")
            {
                OneYearCheckbox.Click();
                OneYearAmount.SendKeys(OneYearYearAmount.ToString());
            }

            if (planType1 == "FourYearCollege")
            {
                FourYearCollegeCheckbox.Click();
            }

            if (planType1 == "TwoPlusTwo")
            {
                TwoPlusTwoCheckbox.Click();
            }

            if (planType1 == "FourYearUniversity")
            {
                FourYearUniversityCheckBox.Click();
            }

            if (SavingsYN)
            {
                SavingsCheckbox.Click();
            }
            NextButton.Click();
        }
        }
    }