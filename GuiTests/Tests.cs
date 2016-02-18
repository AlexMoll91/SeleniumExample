using System;
using System.Globalization;
using System.Text;
using System.Threading;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using Structura.GuiTests.PageObjects;
using Structura.GuiTests.PageObjects.Tests.PageObjects;
using Structura.GuiTests.SeleniumHelpers;
using Structura.GuiTests.Utilities;
using Tests.PageObjects;

namespace Structura.GuiTests
{
    using OpenQA.Selenium.PhantomJS;
    using OpenQA.Selenium.Remote;

    [TestFixture("chrome", "45", "Windows 7", "", "")]
    public class Tests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl = @"http://betacustomeraccess.myfloridaprepaid.com/";
        public static int runCount = 0;
        public static int successCount = 0;
        public static int failCount = 0;
        private String browser;
        private String version;
        private String os;
        private String deviceName;
        private String deviceOrientation;
        
        public Tests(String browser, String version, String os, String deviceName, String deviceOrientation)
        {
            this.browser = browser;
            this.version = version;
            this.os = os;
            this.deviceName = deviceName;
            this.deviceOrientation = deviceOrientation;
            
        }
        [SetUp]
        public void Init()
        {
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, os);
            caps.SetCapability("deviceName", deviceName);
            caps.SetCapability("deviceOrientation", deviceOrientation);
            caps.SetCapability("username", "alexmoll"); // supply sauce labs username
            caps.SetCapability("accessKey", "2a304989-8d68-4c32-aed1-2ec6ba1ca97a");
            caps.SetCapability("name", TestContext.CurrentContext.Test.Name);

            _driver = new PhantomJSDriver();//new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
            //TimeSpan.FromSeconds(600));
                //new PhantomJSDriver(); //
           
            this._driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.MinValue);
        }
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                _driver.Quit();
                _driver.Close();
            }
            catch (Exception)
            {
                // Ignore errors if we are unable to close the browser
            }
         
        }

        [Test]
        
        public void FourYearUniversity_Auto5Year_1dorm_CCApp()
        {
            //plan params: TwoYearCollege, TwoPlusTwo, OneYearUniversity, FourYearUniversity, FourYearCollege
            var planType1 = "FourYearUniversity";
            var planType2 = "";
            var oneyearuniversityAmount = 0;
            var dormYN = true;
            var dormAmount = 1;
            var savingsYN = false;
            var paymentPlanYN = true;
            var paymentType = "FiveYear";
            var checkoutType = "CC";
            
            new LoginPage(_driver).Register(_baseUrl);

            new RegisterPathPage(_driver).NewPlanSelect();

            new RegistrationPage(_driver).Register("4YU1DCC");

            new Step2Page(_driver).Step2();
            
            new Step2DeliveryPage(_driver).Step2DeliveryOptions();
            
            new Step3Page(_driver).Step3();

            new Step4Page(this._driver).Step4SelectPlan(planType1, planType2, savingsYN, oneyearuniversityAmount);

            new Step5Page(this._driver).PaymentPlan(planType1, planType2, oneyearuniversityAmount, paymentType, dormYN, dormAmount);
            
            new Step6Page(this._driver).SubmitResidency(2);

            new Step7Page(this._driver).HowToPay(planType1, planType2, oneyearuniversityAmount, paymentType, paymentPlanYN);
            
            //checkout--savings--buyanother
            new AreYouReadyPage(this._driver).AreYouReady("Checkout");

            new Checkout1Page(this._driver).Checkout1(checkoutType);

            new Checkout2Page(this._driver).Checkout2(savingsYN, true);

            new SubmissionPage(this._driver).SubmissionSuccess();
           
        }

        [Test]

        public void FourYearUniversity_Auto5Year_2dorm_ACHApp()
            {
            //plan params: TwoYearCollege, TwoPlusTwo, OneYearUniversity, FourYearUniversity, FourYearCollege
            var planType1 = "FourYearUniversity";
            var planType2 = "";
            var oneyearuniversityAmount = 0;
            var dormYN = true;
            var dormAmount = 2;
            var savingsYN = false;
            var paymentPlanYN = true;
            var paymentType = "FiveYear";
            var checkoutType = "ACH";

            new LoginPage(_driver).Register(_baseUrl);

            new RegisterPathPage(_driver).NewPlanSelect();

            new RegistrationPage(_driver).Register("4YU2DACH");

            new Step2Page(_driver).Step2();

            new Step2DeliveryPage(_driver).Step2DeliveryOptions();

            new Step3Page(_driver).Step3();

            new Step4Page(this._driver).Step4SelectPlan(planType1, planType2, savingsYN, oneyearuniversityAmount);

            new Step5Page(this._driver).PaymentPlan(planType1, planType2, oneyearuniversityAmount, paymentType, dormYN, dormAmount);

            new Step6Page(this._driver).SubmitResidency(2);

            new Step7Page(this._driver).HowToPay(planType1, planType2, oneyearuniversityAmount, paymentType, paymentPlanYN);

            //checkout--savings--buyanother
            new AreYouReadyPage(this._driver).AreYouReady("Checkout");

            new Checkout1Page(this._driver).Checkout1(checkoutType);

            new Checkout2Page(this._driver).Checkout2(savingsYN, true);

            new SubmissionPage(this._driver).SubmissionSuccess();
            }

        [Test]

        public void FourYearUniversity_Auto5Year_3dorm_MailInApp()
            {
            //plan params: TwoYearCollege, TwoPlusTwo, OneYearUniversity, FourYearUniversity, FourYearCollege
            var planType1 = "FourYearUniversity";
            var planType2 = "";
            var oneyearuniversityAmount = 0;
            var dormYN = true;
            var dormAmount = 3;
            var savingsYN = false;
            var paymentPlanYN = false;
            var paymentType = "FiveYear";
            var checkoutType = "mailin";

            new LoginPage(_driver).Register(_baseUrl);

            new RegisterPathPage(_driver).NewPlanSelect();

            new RegistrationPage(_driver).Register("4YU3D");

            new Step2Page(_driver).Step2();

            new Step2DeliveryPage(_driver).Step2DeliveryOptions();

            new Step3Page(_driver).Step3();

            new Step4Page(this._driver).Step4SelectPlan(planType1, planType2, savingsYN, oneyearuniversityAmount);

            new Step5Page(this._driver).PaymentPlan(planType1, planType2, oneyearuniversityAmount, paymentType, dormYN, dormAmount);

            new Step6Page(this._driver).SubmitResidency(2);

            new Step7Page(this._driver).HowToPay(planType1, planType2, oneyearuniversityAmount, paymentType, paymentPlanYN);

            //checkout--savings--buyanother
            new AreYouReadyPage(this._driver).AreYouReady("Checkout");

            new Checkout1Page(this._driver).Checkout1(checkoutType);

            new Checkout2Page(this._driver).Checkout2(savingsYN, true);

            new SubmissionPage(this._driver).SubmissionSuccess();
            }

        [Test]

        public void 
            TwoPlusTwo_Auto5Year_1dorm_ACHApp()
            {
            //plan params: TwoYearCollege, TwoPlusTwo, OneYearUniversity, FourYearUniversity, FourYearCollege
            var planType1 = "TwoPlusTwo";
            var planType2 = "";
            var oneyearuniversityAmount = 0;
            var dormYN = true;
            var dormAmount = 1;
            var savingsYN = false;
            var paymentPlanYN = true;
            var paymentType = "FiveYear";
            var checkoutType = "ACH";

            new LoginPage(_driver).Register(_baseUrl);

            new RegisterPathPage(_driver).NewPlanSelect();

            new RegistrationPage(_driver).Register("TPT1D");

            new Step2Page(_driver).Step2();

            new Step2DeliveryPage(_driver).Step2DeliveryOptions();

            new Step3Page(_driver).Step3();

            new Step4Page(this._driver).Step4SelectPlan(planType1, planType2, savingsYN, oneyearuniversityAmount);

            new Step5Page(this._driver).PaymentPlan(planType1, planType2, oneyearuniversityAmount, paymentType, dormYN, dormAmount);

            new Step6Page(this._driver).SubmitResidency(2);

            new Step7Page(this._driver).HowToPay(planType1, planType2, oneyearuniversityAmount, paymentType, paymentPlanYN);

            //checkout--savings--buyanother
            new AreYouReadyPage(this._driver).AreYouReady("Checkout");

            new Checkout1Page(this._driver).Checkout1(checkoutType);

            new Checkout2Page(this._driver).Checkout2(savingsYN, true);

            new SubmissionPage(this._driver).SubmissionSuccess();
            }

        [Test]

        public void TwoYearCollege_Monthly_0dorm_ACH()
            {
            //plan params: TwoYearCollege, TwoPlusTwo, OneYearUniversity, FourYearUniversity, FourYearCollege
            var planType1 = "TwoYearCollege";
            var planType2 = "";
            var oneyearuniversityAmount = 0;
            var dormYN = false;
            var dormAmount = 0;
            var savingsYN = false;
            var paymentPlanYN = true;
            var paymentType = "Monthly";
            var checkoutType = "ACH";

            new LoginPage(_driver).Register(_baseUrl);

            new RegisterPathPage(_driver).NewPlanSelect();

            new RegistrationPage(_driver).Register("2YM0DACH");

            new Step2Page(_driver).Step2();

            new Step2DeliveryPage(_driver).Step2DeliveryOptions();

            new Step3Page(_driver).Step3();

            new Step4Page(this._driver).Step4SelectPlan(planType1, planType2, savingsYN, oneyearuniversityAmount);

            new Step5Page(this._driver).PaymentPlan(planType1, planType2, oneyearuniversityAmount, paymentType, dormYN, dormAmount);

            new Step6Page(this._driver).SubmitResidency(2);

            new Step7Page(this._driver).HowToPay(planType1, planType2, oneyearuniversityAmount, paymentType, paymentPlanYN);

            //checkout--savings--buyanother
            new AreYouReadyPage(this._driver).AreYouReady("Checkout");

            new Checkout1Page(this._driver).Checkout1(checkoutType);

            new Checkout2Page(this._driver).Checkout2(savingsYN, true);

            new SubmissionPage(this._driver).SubmissionSuccess();
            }
        
    }
}


