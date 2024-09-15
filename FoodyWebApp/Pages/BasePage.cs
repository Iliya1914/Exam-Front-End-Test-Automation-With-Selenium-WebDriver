using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FoodyWebApp.Pages
{
    public class BasePage
    {
        protected IWebDriver driver;

        protected WebDriverWait wait;

        public string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85";

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        public IWebElement AddFoodLink => driver.FindElement(By.XPath("//a[text() = 'Add Food']"));
        public IWebElement AddFoodButton => driver.FindElement(By.XPath("//a[text() = 'Add food']"));

        public ReadOnlyCollection<IWebElement> AllFoodList => driver.FindElements(By.XPath("//div[@class = 'row gx-5 align-items-center']"));

        public IWebElement LastFoodTitle => AllFoodList.Last().FindElement(By.XPath(".//h2"));
        public IWebElement LastFoodEditButton => AllFoodList.Last().FindElement(By.XPath(".//a[text() = 'Edit']"));
        public IWebElement LastFoodDeleteButton => AllFoodList.Last().FindElement(By.XPath(".//a[text() = 'Delete']"));
        public IWebElement SearchInput => AllFoodList.Last().FindElement(By.XPath("//input[@type = 'search']"));
        public IWebElement SearchButton => AllFoodList.Last().FindElement(By.XPath("//button[@type = 'submit']"));

        public ReadOnlyCollection<IWebElement> AllFoodListAfterSearch => driver.FindElements(By.XPath("//div[@class = 'row gx-5 align-items-center']"));

        public IWebElement LastFoodTitleAfterSearch => AllFoodList.Last().FindElement(By.XPath(".//h2"));

        public IWebElement NoFoodMessageAfterSearch => AllFoodList.Last().FindElement(By.XPath("//div[@class = 'p-5']//h2"));

        public virtual void OpenPage()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }

    }
}
