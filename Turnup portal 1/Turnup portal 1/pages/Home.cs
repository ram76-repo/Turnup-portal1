using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Turnup_portal_1.pages
{
    public class Home
    {
        public void NavigatetoTMPage(IWebDriver driver)
        {
            IWebElement adminMenu = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a"));
            adminMenu.Click();

            //navigate to Time and Material section
            IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/ul/li[3]/a"));
            timeAndMaterial.Click();
        }
    }
}
