using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Tests.PageObjects;

namespace Structura.GuiTests.PageObjects
{
    using System;
    using OpenQA.Selenium.Support.UI;

    public class MainPage
    {
        private readonly IWebDriver _driver;

        public MainPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        [FindsBy(How = How.Id, Using = "btnGetAccount")]
        public IWebElement GetAccountButton { get; set; }

        [FindsBy(How = How.Id, Using = "_ctl0__ctl0_Content_MenuHyperLink3")]
        public IWebElement TransferFundsButton { get; set; }
        public static bool WaitUntilElementIsPresent(IWebDriver driver, IWebElement webele, int timeout = 10)
            {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(d => webele.Displayed && webele.Enabled);
            }
        public TransferFundsPage NavigateToTransferFunds()
        {
            TransferFundsButton.Click();
            return new TransferFundsPage(_driver);
        }
    }
}
