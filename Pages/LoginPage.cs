using Core.PageObject;
using Entities;
using FrameworkCore;
using FrameworkCore.TestUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Threading;

namespace Pages
{

    public class LoginPage : BasePage
    {
        private readonly string expectedURL = "Account/Login";
        private WebElementProxy userName;
        private WebElementProxy password;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            InitializeElements();
        }

        private void InitializeElements()
        {
            userName = new WebElementProxy(driver, By.Id("Email"));
            password = new WebElementProxy(driver, By.Id("Password"));
        }

        public void Login(Entities.User user)
        {
            EnterUserName(user);
            EnterPassword(user);
        }

        private void EnterUserName(Entities.User user)
        {
            userName.Get().Clear();
            userName.Get().SendKeys(user.UserName);
        }

        private void EnterPassword(Entities.User user)
        {
            Thread.Sleep(1000);            
            password.Get().Clear();
            password.Get().SendKeys(user.Password);
            password.Get().Submit();
            Thread.Sleep(10000);
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl(Utilities.GetEnvironmentUrl());
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(drv => drv.Url.Contains(expectedURL));
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains(expectedURL);
        }
    }
}