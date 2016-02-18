using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    using System;
    using OpenQA.Selenium.Support.UI;

    public class Step5Page
    {
        private readonly IWebDriver _driver;

        public Step5Page(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity4MonthlyPayment")]
        public IWebElement FourYearMonthlyRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity4MonthlyPayment")]
        public IWebElement FourYearFiveYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_txt1YearUniversityPlanQuantity")]
        public IWebElement FourYearLumpSumRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_ddlDormitoryPaymentPlan")]
        public IWebElement DormitoryDropdown { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbDormitory1Year")]
        public IWebElement DormitoryOneYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbDormitory2Year")]
        public IWebElement DormitoryTwoYearRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbDormitory3Year")]
        public IWebElement DormitoryThreeYearRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbDormitory4Year")]
        public IWebElement DormitoryFourYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbDormitoryNoThanks")]
        public IWebElement DormitoryNoRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_btnSubmitPaymentsAndAddOns")]
        public IWebElement NextButton { get; set; }


        public void PaymentPlan(string planType1, string planType2, string paymentPlan, bool DormYN, int DormAmount)
        {
            if (planType1 == "FourYearUniversity")
            {
                switch (paymentPlan)
                {
                    case "Monthly":
                        FourYearMonthlyRadio.Click();
                        break;
                    case "FiveYear":
                        FourYearFiveYearRadio.Click();
                        break;
                    case "Lumpsum":
                        FourYearLumpSumRadio.Click();
                        break;
                }
            }
            if (DormYN)
            {
                switch (DormAmount)
                {
                    case 1:
                        DormitoryOneYearRadio.Click();
                        break;
                    case 2:
                        DormitoryTwoYearRadio.Click();
                        break;
                    case 3:
                        DormitoryThreeYearRadio.Click();
                        break;
                    case 4:
                        DormitoryFourYearRadio.Click();
                        break;
                    case 0:
                        DormitoryNoRadio.Click();
                        break;
                }
            }
            NextButton.Click();
        }
    }
}