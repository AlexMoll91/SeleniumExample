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

            _driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), caps,
                TimeSpan.FromSeconds(600));
            
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
        [Repeat(15)]

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


