using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.SeleniumHelpers;

namespace Tests.PageObjects
{
    using System;
    using System.Threading;
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


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity4FiveYearPayment")]
        public IWebElement FourYearFiveYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity4PlanLumpSumPayment")]
        public IWebElement FourYearLumpSumRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoPlusTwoFloridaPlanMonthlyPayment")]
        public IWebElement TwoPlusTwoMonthlyRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbTwoPlusTwoFloridaPlanFiveYearPayment")]
        public IWebElement TwoPlusTwoFiveYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoPlusTwoFloridaPlanFiveYearPayment")]
        public IWebElement TwoPlusTwoLumpSumRadio { get; set; }
        
        [FindsBy(How = How.Id, Using = "cphBody_rbFourYearFloridaCollegePlanMonthlyPayment")]
        public IWebElement FourYearCollegeMonthlyRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbFourYearFloridaCollegePlanFiveYearPayment")]
        public IWebElement FourYearCollegeFiveYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbFourYearFloridaCollegePlanLumpSumPayment")]
        public IWebElement FourYearCollegeLumpSumRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoYearFloridaCollegePlanMonthlyPayment")]
        public IWebElement TwoYearCollegeMonthlyRadio { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbTwoYearFloridaCollegePlanFiveYearPayment")]
        public IWebElement TwoYearCollegeFiveYearRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoYearFloridaCollegePlanLumpSumPayment")]
        public IWebElement TwoYearCollegeLumpSumRadio { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanMonthlyPayment1")]
        public IWebElement University1MonthlyRadio1 { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanFiveYearPayment1")]
        public IWebElement University1FiveYearRadio1 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanLumpSumPayment1")]
        public IWebElement University1LumpSumRadio1 { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanMonthlyPayment2")]
        public IWebElement University1MonthlyRadio2 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanFiveYearPayment2")]
        public IWebElement University1FiveYearRadio2 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanLumpSumPayment2")]
        public IWebElement University1LumpSumRadio2 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoPlusTwoFloridaPlanMonthlyPayment3")]
        public IWebElement University1MonthlyRadio3 { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanMonthlyPayment3")]
        public IWebElement University1FiveYearRadio3 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanLumpSumPayment3")]
        public IWebElement University1LumpSumRadio3 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbTwoPlusTwoFloridaPlanMonthlyPayment4")]
        public IWebElement University1MonthlyRadio4 { get; set; }


        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanMonthlyPayment4")]
        public IWebElement University1FiveYearRadio4 { get; set; }

        [FindsBy(How = How.Id, Using = "cphBody_rbUniversity1FloridaPlanLumpSumPayment4")]
        public IWebElement University1LumpSumRadio4 { get; set; }



        
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


        public void PaymentPlan(string planType1, string planType2, int oneyearAmount, string paymentPlan, bool DormYN, int DormAmount)
        {
            Thread.Sleep(2000);
            this._driver.FindElement(By.Id("cphBody_pnlSubmit")).Click();
            if (planType1 == "FourYearUniversity")
            {
                switch (paymentPlan.ToLower())
                {
                    case "monthly":
                        FourYearMonthlyRadio.Click();
                        break;
                    case "fiveyear":
                        FourYearFiveYearRadio.Click();
                        break;
                    case "lumpsum":
                        FourYearLumpSumRadio.Click();
                        break;
                }
            }
            if (planType1 == "TwoPlusTwo")
                {
                switch (paymentPlan.ToLower())
                    {
                    case "monthly":
                        TwoPlusTwoMonthlyRadio.Click();
                        break;
                    case "fiveyear":
                        TwoPlusTwoFiveYearRadio.Click();
                        break;
                    case "lumpsum":
                        TwoPlusTwoLumpSumRadio.Click();
                        break;
                    }
                }
            if (planType1 == "FourYearCollege")
                {
                switch (paymentPlan.ToLower())
                    {
                    case "monthly":
                        FourYearCollegeMonthlyRadio.Click();
                        break;
                    case "fiveyear":
                        FourYearCollegeFiveYearRadio.Click();
                        break;
                    case "lumpsum":
                        FourYearCollegeLumpSumRadio.Click();
                        break;
                    }
                }
            if (planType1 == "OneYearUniversity" || planType2 == "OneYearUniversity")
            {
                switch (oneyearAmount.ToString()+" "+paymentPlan.ToLower())
                {
                    case "1 monthly":
                        University1MonthlyRadio1.Click();
                        break;
                    case "2 monthly":
                        University1MonthlyRadio1.Click();
                        University1MonthlyRadio2.Click();
                        break;
                    case "3 monthly":
                        University1MonthlyRadio1.Click();
                        University1MonthlyRadio2.Click();
                        University1MonthlyRadio3.Click();
                        break;
                    case "4 monthly":
                        University1MonthlyRadio1.Click();
                        University1MonthlyRadio2.Click();
                        University1MonthlyRadio3.Click();
                        University1MonthlyRadio4.Click();
                        break;
                    case "1 fiveyear":
                        University1FiveYearRadio1.Click();
                        break;
                    case "2 fiveyear":
                        University1FiveYearRadio1.Click();
                        University1FiveYearRadio2.Click();
                        break;
                    case "3 fiveyear":
                        University1FiveYearRadio1.Click();
                        University1FiveYearRadio2.Click();
                        University1FiveYearRadio3.Click();
                        break;
                    case "4 fiveyear":
                        University1FiveYearRadio1.Click();
                        University1FiveYearRadio2.Click();
                        University1FiveYearRadio3.Click();
                        University1FiveYearRadio4.Click();
                        break;
                    case "1 lumpsum":
                        University1LumpSumRadio1.Click();
                        break;
                    case "2 lumpsum":
                        University1LumpSumRadio1.Click();
                        University1LumpSumRadio2.Click();
                        break;
                    case "3 lumpsum":
                        University1LumpSumRadio1.Click();
                        University1LumpSumRadio2.Click();
                        University1LumpSumRadio3.Click();
                        break;
                    case "4 lumpsum":
                        University1LumpSumRadio1.Click();
                        University1LumpSumRadio2.Click();
                        University1LumpSumRadio3.Click();
                        University1LumpSumRadio4.Click();
                        break;

                }
            }
            if (planType1 == "TwoYearCollege" || planType2 == "TwoYearCollege")
                {
                switch (paymentPlan.ToLower())
                    {
                    case "monthly":
                        TwoYearCollegeMonthlyRadio.Click();
                        break;
                    case "fiveyear":
                        TwoYearCollegeFiveYearRadio.Click();
                        break;
                    case "lumpsum":
                        TwoYearCollegeLumpSumRadio.Click();
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