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
        using Data;
        using Tests = GuiTests.Tests;


        public class RegistrationPage
        {
            private readonly IWebDriver _driver;

            public RegistrationPage(IWebDriver driver)
            {
                _driver = driver;
                PageFactory.InitElements(_driver, this);
            }

            [FindsBy(How = How.Id, Using = "cphBody_txtEmailAddress")]
            public IWebElement EmailField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtRetypeEmailAddress")]
            public IWebElement EmailConfirmField { get; set; }

            [FindsBy(How = How.XPath, Using = "//input[@id='cphBody_txtCreateUsername']")]
            public IWebElement UsernameField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtCreatePassword")]
            public IWebElement PasswordField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtCreatePasswordRetype")]
            public IWebElement ConfirmPasswordField { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_ddlSecurityQuestion")]
            public IWebElement SecurityQuestionDropdown { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_txtSecurityAnswer")]
            public IWebElement SecurityQuestionAnswer { get; set; }

            [FindsBy(How = How.Id, Using = "cphBody_btnCreateAccount")]
            public IWebElement NextButton { get; set; }
            
            public void Register(string planType)
            {
                var d = new Data.AccountInfo();

               
                EmailField.SendKeys(planType+d.Email);
                EmailConfirmField.SendKeys(planType+d.Email);
                UsernameField.SendKeys(planType+d.username);
                PasswordField.SendKeys(d.Password);
                ConfirmPasswordField.SendKeys(d.Password);
                SelectElement SecurityQuestionDrop = new SelectElement(SecurityQuestionDropdown);
                SecurityQuestionDrop.SelectByText(d.Securityselection);
                SecurityQuestionAnswer.SendKeys(d.Securityanswer);
                Console.WriteLine(d.username);
                Console.WriteLine(d.Securityanswer);
                NextButton.Click();

                if (this._driver.Url == @"https://betacustomeraccess.myfloridaprepaid.com/enrollment/accountowner.aspx")
                {
                    Tests.successCount++;
                    Console.WriteLine("[SUCCESS RUN #" + Tests.runCount + "] [User: " + d.username + " created]");
                }
                else
                {
                    Tests.failCount++;
                    Console.WriteLine("[FAIL] [RUN #" + Tests.runCount + "]" + "[User: " + d.username + " not created]");
                }


            }
            
        }


    }
}
