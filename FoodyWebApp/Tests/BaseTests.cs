using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodyWebApp.Pages;

namespace FoodyWebApp.Tests
{
    public class BaseTests
    {
        public IWebDriver driver;

        public Actions actions;

        public LoginPage loginPage;

        public AddFoodPage addFoodPage;

        public BasePage basePage;

        public EditFoodPage editFoodPage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            options.AddArgument("--disable-search-engine-choice-screen");

            driver = new ChromeDriver(options);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            actions = new Actions(driver);

            loginPage = new LoginPage(driver);

            addFoodPage = new AddFoodPage(driver);

            basePage = new BasePage(driver);

            editFoodPage = new EditFoodPage(driver);

            loginPage.OpenPage();

            loginPage.Login("testuser72", "123456");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        public string GenerateRandomString()
        {
            Random random = new Random();

            return random.Next(1000, 10000).ToString();
        }

    }
}
