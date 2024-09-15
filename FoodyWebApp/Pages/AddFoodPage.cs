using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class AddFoodPage : BasePage
    {
        public string Url => $"{BaseUrl}/Food/Add";

        public AddFoodPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FoodNameInput => driver.FindElement(By.XPath("//input[@id = 'name']"));
        public IWebElement DescriptionInput => driver.FindElement(By.XPath("//input[@id = 'description']"));
        public IWebElement AddFoodButton => driver.FindElement(By.XPath("//button[@type = 'submit']"));
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("//li[contains(text(), 'Unable to add this food revue!')]"));

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
