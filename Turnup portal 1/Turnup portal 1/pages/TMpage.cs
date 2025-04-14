using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Turnup_portal_1.pages
{
    public class TMpage
    {
        public void TMsection(IWebDriver driver)
        {
            IWebElement createNew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNew.Click();
            Thread.Sleep(1000);

            //Select type code drop down

            IWebElement typecode = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typecode.Click();
            Thread.Sleep(1000);

            //select time option

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();
            Thread.Sleep(1000);

            //type the code

            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("XX123");
            Thread.Sleep(1000);

            //type the description

            IWebElement desc = driver.FindElement(By.Id("Description"));
            desc.SendKeys("This is a new record");
            Thread.Sleep(1000);

            // type price per unit

            IWebElement price = driver.FindElement(By.XPath("//*[@id=\"Price\"]"));
            price.SendKeys("3500");
            Thread.Sleep(1000);

            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveButton.Click();
        }
    }
}
