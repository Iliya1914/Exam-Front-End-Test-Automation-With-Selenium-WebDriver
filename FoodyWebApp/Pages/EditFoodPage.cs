﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodyWebApp.Pages
{
    public class EditFoodPage : AddFoodPage
    {
        public EditFoodPage(IWebDriver driver) : base(driver)
        {
        }
    }
}
