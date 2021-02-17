using Components;
using FrameworkCore;
using NUnit.Framework;
using Pages;
using Entities;
using System.Threading;
using System;


namespace TestLibrary
{
    //[TestFixture("ie")]
    // [TestFixture("firefox")]
    [TestFixture("chrome")]
    // [Parallelizable]
    class LoginTest_01 : BaseTest
    {
        private LoginPage loginPage;
        private HeaderComponent headerComponent;
        private LandingPage landingPage;

        public LoginTest_01(string browser) : base(browser) { }

        [SetUp]
        public void SetUp()
        {
            loginPage = new LoginPage(driver);
            loginPage.Load();
            landingPage = new LandingPage(driver, loginPage);
            headerComponent = new HeaderComponent(driver);
        }

        [Test]
        [Description("Navigate to Home/Dashboard page and validate side menu components/ links exist.")]
        [Category("SmokeTesting")] // [Order(1)]
        public void ValidateLoginUser1()
        {
            loginPage.Login(User.USER1);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");

        }

        [Test]
        [Description("navigate to home/dashboard page and validate side menu components/ links exist.")]
        [Category("SmokeTesting")] //[Order(2)]
        public void ValidateLoginUser2()
        {
            loginPage.Login(User.USER2);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
        }
        

        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headerComponent.GoToLogout();
        }
    }
}