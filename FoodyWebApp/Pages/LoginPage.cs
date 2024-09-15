using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class LoginPage : BasePage
    {
        public string Url => $"{BaseUrl}/User/Login";
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement UsernameInput => driver.FindElement(By.XPath("//input[@id = 'username']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@id = 'password']"));
        public IWebElement LoginButon => driver.FindElement(By.XPath("//button[@type = 'submit']"));

        public void Login(string username, string password)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            LoginButon.Click();
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
