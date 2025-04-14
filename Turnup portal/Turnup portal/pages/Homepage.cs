using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Turnup_portal.pages
{
    public class Homepage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            
            IWebElement admindropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            admindropdown.Click();

            IWebElement timeandelement = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeandelement.Click();
            Thread.Sleep(3000);

        }
    }
}
