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
    [TestFixture]
    public class Tests
    {
        private IWebDriver _driver;
        private StringBuilder _verificationErrors;
        private string _baseUrl;
        public static int runCount = 0;
        public static int successCount = 0;
        public static int failCount = 0;
        [SetUp]
        public void SetupTest()
        {
            _driver = new DriverFactory().Create();
            
            _baseUrl = ConfigurationHelper.Get<string>("TargetUrl");
            _verificationErrors = new StringBuilder();
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
            _verificationErrors.ToString().Should().BeEmpty("No verification errors are expected.");
        }

        [Test]
        [Repeat(45)]
        public void RegisterNewUser()
        {
            
            
            // Arrange
            // Act
            new LoginPage(_driver).Register(_baseUrl);

            // Assert
            var registerpathPage = new RegisterPathPage(_driver);
            registerpathPage.NewPlanButton.Displayed.Should().BeTrue();
            registerpathPage.NewPlanSelect();
            var rp = new RegistrationPage(_driver);
            rp.EmailField.Displayed.Should().BeTrue();
            rp.Register();
            runCount++;
            
            
            
        }

        
    }
}


