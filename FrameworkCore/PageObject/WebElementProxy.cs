using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Core.PageObject
{
    public class WebElementProxy
    {
        private By locator;
        private IWebDriver driver;
        public WebElementProxy(IWebDriver driver, By locator)
        {
            this.locator = locator;
            this.driver = driver;
        }

        public IWebElement Get()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(drv => drv.FindElement(locator));
        }

        public bool IsInteractable()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(drv => Get().Enabled);
        }

        public bool IsPresent()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait.Until(drv => Get().Displayed);
        }
    }
}
