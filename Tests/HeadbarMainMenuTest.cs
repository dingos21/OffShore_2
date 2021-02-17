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
    internal class HeadbarMainMenuTest: BaseTest
    {
        private LoginPage loginPage;
        private HeaderComponent headerComponent;
        private LandingPage landingPage;

        public HeadbarMainMenuTest(string browser) : base(browser) { }

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
        public void ValidateHeadMenu01()
        {
            loginPage.Login(User.USER1);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
            Assert.Multiple(() =>
            {
                Assert.True(headerComponent.ValidatePimsSupportMenuEnabled(), "Pims Support Menu is not enabled");
                //Assert.True(headerComponent.ValidateBondMenuEnabled(), "Bond Menu is not enabled");

            });
        }

        [Test]
        [Description("navigate to home/dashboard page and validate side menu components/ links exist.")]
        [Category("SmokeTesting")] //[Order(2)]
        public void ValidateHeadMenu02()
        {
            loginPage.Login(User.USER1);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
            Assert.Multiple(() =>
            {
                Assert.True(headerComponent.ValidateCapsMenuEnabled(), "CAPS Menu is not enabled");
                Assert.True(headerComponent.ValidateCftMenuEnabled(), "CFT Menu is not enabled");

            });
        }
        [Test]
        [Description("Navigate to Home/Dashboard page and validate side menu components/ links exist.")]
        [Category("RegressionTesting")] // [Order(1)]
        public void ValidateHeadMenu03()
        {
            loginPage.Login(User.USER2);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
            Assert.Multiple(() =>
            {
                Assert.True(headerComponent.ValidateIcpiSetupMenuEnabled(), "ICPI Menu is not enabled");
                Assert.True(headerComponent.ValidateLspdMenuEnabled(), "LSPD Menu is not enabled");
            });
        }

        [Test]
        [Description("navigate to home/dashboard page and validate side menu components/ links exist.")]
        [Category("RegressionTesting")] //[Order(2)]
        public void VValidateHeadMenu04()
        {
            loginPage.Login(User.USER2);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
            Assert.Multiple(() =>
            {
                Assert.True(headerComponent.ValidatePimsMenuEnabled(), "PIMS Menu is not enabled");
                Assert.True(headerComponent.ValidateSecurityMenuEnabled(), "Security Menu is not enabled");
            });
        }
        [Test]
        [Description("navigate to home/dashboard page and validate side menu components/ links exist.")]
        [Category("RegressionTesting")] //[Order(2)]
        public void ValidateHeadMenu05()
        {
            loginPage.Login(User.USER2);
            Assert.True(driver.Url.ToLower().Contains(landingPage.homeURL), "Home/Dashboard Page did not load");
            Assert.Multiple(() =>
            {
                Assert.True(headerComponent.ValidateSystemMaintenanceMenuEnabled(), "System Maintenance Menu is not enabled");
                Assert.True(headerComponent.ValidateDataStoreMenuEnabled(), "Data Store Menu is not enabled");
            });
        }

        [TearDown]
        public void LogoutCenterPoint()
        {
            landingPage.EvaluateScreenshotSourcePageSaving();
            headerComponent.GoToLogout();
        }
    }
}



/*------------------------

                Assert.True(headerComponent.ValidatePimsSupportMenuEnabled(), "Pims Support Menu is not enabled");
                Assert.True(headerComponent.ValidateBondMenuEnabled(), "Bond Menu is not enabled");
                Assert.True(headerComponent.ValidateCapsMenuEnabled(), "CAPS Menu is not enabled");
                Assert.True(headerComponent.ValidateCftMenuEnabled(), "CFT Menu is not enabled");
                Assert.True(headerComponent.ValidateIcpiSetupMenuEnabled(), "ICPI Menu is not enabled");
                Assert.True(headerComponent.ValidateLspdMenuEnabled(), "LSPD Menu is not enabled");
                Assert.True(headerComponent.ValidatePimsMenuEnabled(), "PIMS Menu is not enabled");
                Assert.True(headerComponent.ValidateSecurityMenuEnabled(), "Security Menu is not enabled");
                Assert.True(headerComponent.ValidateSystemMaintenanceMenuEnabled(), "System Maintenance Menu is not enabled");
                Assert.True(headerComponent.ValidateDataStoreMenuEnabled(), "Data Store Menu is not enabled");

-------------------------*/