using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Turnup_portal.utilities;

namespace Turnup_portal.pages
{
    public class Loginpage
    {
        public void LoginActions(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

            //login validation

            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");
                        
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"loginForm\"]/form/div[3]/input[1]", 10);

            IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            login.Click();
        }
    }
}
