using Core.PageObject;
using FrameworkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace Components
{
    public class HeaderComponent : BaseComponent
    {
        private WebElementProxy pimsSupportMenu;
        private WebElementProxy bondMenu;
        private WebElementProxy capsMenu;
        private WebElementProxy cftMenu;
        private WebElementProxy icpiSetupMenu;
        private WebElementProxy lspdMenu;
        private WebElementProxy pimsMenu;
        private WebElementProxy securityMenu;
        private WebElementProxy systemMaintenanceMenu;
        private WebElementProxy dataStoreMenu;
        private WebElementProxy logoutMenu;

        //public string rolesURL = "roles/search";
        //public string groupsURL = "groups/search";
        //public string profilesURL = "profiles/search";
        //public string lendersURL = "lenderprofile/search";
        //public string systemAdminURL = "users/search";
        //public string contactAlliedURL = "";
        //public string myProfileURL = "profile/detail";
        public string logoutURL = "PimsSupport/";

        public HeaderComponent(IWebDriver driver) : base(driver)
        {
            InitializeElements();
        }

        private void InitializeElements()
        {
            pimsSupportMenu = new WebElementProxy(driver, By.LinkText("PIMS Support"));
            bondMenu = new WebElementProxy(driver, By.LinkText("Bond"));
            capsMenu = new WebElementProxy(driver, By.LinkText("CAPS"));
            cftMenu = new WebElementProxy(driver, By.LinkText("CFT"));
            icpiSetupMenu = new WebElementProxy(driver, By.LinkText("iCPI Setup"));
            lspdMenu = new WebElementProxy(driver, By.LinkText("LSPD"));
            pimsMenu = new WebElementProxy(driver, By.LinkText("PIMS"));
            securityMenu = new WebElementProxy(driver, By.LinkText("Security"));
            systemMaintenanceMenu = new WebElementProxy(driver, By.LinkText("System Maintenance"));
            dataStoreMenu = new WebElementProxy(driver, By.LinkText("Data Store"));
            logoutMenu = new WebElementProxy(driver, By.LinkText("Log off"));
        }

        //public bool ValidateSupportSubMenusEnabled()
        //{
        //    ActivateSubMenus(pimsSupportMenu);
        //    return 
        //        //systemAdminSubMenu.IsPresent() && systemAdminSubMenu.IsInteractable() &&
        //        //contactAlliedSubmenu.IsPresent() && contactAlliedSubmenu.IsInteractable() &&
        //        //chatWithSupportSubmenu.IsPresent() && chatWithSupportSubmenu.IsInteractable();
        //}


        public bool ValidatePimsSupportMenuEnabled() { return pimsSupportMenu.IsPresent() && pimsSupportMenu.IsInteractable(); }
        public bool ValidateBondMenuEnabled() { return bondMenu.IsPresent() && bondMenu.IsInteractable(); }
        public bool ValidateCapsMenuEnabled() { return capsMenu.IsPresent() && capsMenu.IsInteractable(); }
        public bool ValidateCftMenuEnabled() { return cftMenu.IsPresent() && cftMenu.IsInteractable(); }
        public bool ValidateIcpiSetupMenuEnabled() { return icpiSetupMenu.IsPresent() && icpiSetupMenu.IsInteractable(); }
        public bool ValidateLspdMenuEnabled() { return lspdMenu.IsPresent() && lspdMenu.IsInteractable(); }
        public bool ValidatePimsMenuEnabled() { return pimsMenu.IsPresent() && pimsMenu.IsInteractable(); }
        public bool ValidateSecurityMenuEnabled() { return securityMenu.IsPresent() && securityMenu.IsInteractable(); }
        public bool ValidateSystemMaintenanceMenuEnabled() { return systemMaintenanceMenu.IsPresent() && systemMaintenanceMenu.IsInteractable(); }
        public bool ValidateDataStoreMenuEnabled() { return dataStoreMenu.IsPresent() && dataStoreMenu.IsInteractable(); }


        private void ActivateSubMenus(WebElementProxy webElement)
        {
            //TODO: Try in multiple browsers
            //Try click first...
            //webElement.Get().Click();
            //or this
            //HERE IS AN EXAMPLE OF USING A MOUSEOVER EVENT IN SELENIUM
            Actions action = new Actions(driver);
            action.MoveToElement(webElement.Get()).Click().Build().Perform();
        }

        //public void GoToRoles()
        //{
        //    rolesSubMenu.Get().Click();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(drv => drv.Url.Contains(rolesURL));
        //}

        //public void GoToGroups()
        //{
        //    ActivateSubMenus(pimsSupportMenu);
        //    ActivateSubMenus(centerPointAdminSubMenu);
        //    groupsSubMenu.Get().Click();
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        //    wait.Until(drv => drv.Url.Contains(groupsURL));
        //}


        public void GoToLogout()
        {
            logoutMenu.Get().Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Contains(logoutURL));
        }
    }
}