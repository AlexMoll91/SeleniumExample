using System;
using System.Configuration;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Remote;
using Structura.GuiTests.Utilities;
using Tests.SeleniumHelpers;

namespace Structura.GuiTests.SeleniumHelpers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq.Expressions;
    using System.Runtime.Remoting.Messaging;

    public enum DriverToUse
    {
        InternetExplorer,
        Chrome,
        Firefox,
        PhantomJS
    }

    public class DriverFactory
    {
        private static readonly FirefoxProfile FirefoxProfile = CreateFirefoxProfile();
        
        private static FirefoxProfile CreateFirefoxProfile()
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.SetPreference("network.automatic-ntlm-auth.trusted-uris", "http://localhost:4444/wd/hub");
            return firefoxProfile;
        }
        List<string> a = new List<string>(); 
        public IWebDriver Create()
        {
            IWebDriver driver;
            Func<string, string, string> c = (x,y) => x.Replace(x,y);
            var currentDay = "Friday";
            var horribleDay = "Monday";
            var differentDay = c(currentDay, "horribleDay");
            var driverToUse = ConfigurationHelper.Get<DriverToUse>("DriverToUse");
            var useGrid = ConfigurationHelper.Get<bool>("UseGrid");
            if (useGrid)
            {
                driver = CreateGridDriver(driverToUse);
            }
            else
            {
                
                switch (driverToUse)
                {
                    case DriverToUse.InternetExplorer:
                        driver = new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory, new InternetExplorerOptions(), TimeSpan.FromMinutes(5));
                        break;
                    case DriverToUse.Firefox:
                        var firefoxProfile = FirefoxProfile;
                        driver = new FirefoxDriver(firefoxProfile);
                        driver.Manage().Window.Maximize();
                        break;
                    case DriverToUse.Chrome:
                        driver = new ChromeDriver();
                        break;
                    case DriverToUse.PhantomJS:
                        driver = new PhantomJSDriver();
                        PhantomJSOptions o = new PhantomJSOptions();
                        
                    
                        
                        
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            driver.Manage().Window.Maximize();
            var timeouts = driver.Manage().Timeouts();

            timeouts.ImplicitlyWait(TimeSpan.FromSeconds(ConfigurationHelper.Get<int>("ImplicitlyWait")));
            timeouts.SetPageLoadTimeout(TimeSpan.FromSeconds(ConfigurationHelper.Get<int>("PageLoadTimeout")));

            // Suppress the onbeforeunload event first. This prevents the application hanging on a dialog box that does not close.
            //((IJavaScriptExecutor)driver).ExecuteScript("window.onbeforeunload = function(e){};");
            return driver;
        }

        public static IWebDriver CreateGridDriver(DriverToUse driverToUse)
        {
            var gridUrl = ConfigurationManager.AppSettings["GridUrl"];
            var desiredCapabilities = DesiredCapabilities.InternetExplorer();
            switch (driverToUse)
            {
                case DriverToUse.Firefox:
                    desiredCapabilities = DesiredCapabilities.Firefox();
                    desiredCapabilities.SetCapability(FirefoxDriver.ProfileCapabilityName, FirefoxProfile);

                    break;
                case DriverToUse.InternetExplorer:
                    desiredCapabilities = DesiredCapabilities.InternetExplorer();
                    break;
                case DriverToUse.Chrome:
                    desiredCapabilities = DesiredCapabilities.Chrome();
                    break;
                case DriverToUse.PhantomJS:

                    desiredCapabilities = DesiredCapabilities.PhantomJS();
                    PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
                    service.GridHubUrl = gridUrl;
                    
                    break;
            }
            desiredCapabilities.IsJavaScriptEnabled = true;
            var remoteDriver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), desiredCapabilities);
            
            
            return remoteDriver;
        }
    }
}

namespace LambdaPractice
{
	public class RandomStranger
	{
		
		public Random R = new Random();
		public static string Day1;
		
		public enum DayOfWeek
		{
			Monday,
			Tuesday,
			Wednesday,
			Thursday,
			Friday,
			Saturday,
			Sunday
		}

		public static string GroundHogDaySwitcher(int currentdayIndex, int horribledayIndex)
		{
			
			var enumValues = Enum.GetValues(typeof(DayOfWeek));

            Day1 = enumValues.GetValue(currentdayIndex).ToString();
            string day2 = enumValues.GetValue(horribledayIndex).ToString();
			
            //Lambda?
			Func<string, string, string> screwupDay = (x, y) => x.Replace(x, y);
			return screwupDay(Day1, day2);
		}

		public void Main()
		{
			//Lambda?
			Func<int> getday = () => this.R.Next(0,6);

			var randomDay2 = GroundHogDaySwitcher(getday(), getday());
			Console.WriteLine("Bruh... What day is it??? It was ["+Day1+"] when I drank four 2-liters of Dorito-fused Mountain Dew");
			Console.WriteLine("Aww. Fuck. I can't believe I done this. It's ["+randomDay2+"] Unbelieveable.");
		}
	}
}