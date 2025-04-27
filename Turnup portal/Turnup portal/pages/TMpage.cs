using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Turnup_portal.utilities;

namespace Turnup_portal.pages
{
    public class TMpage : CommonDriver
    {
        public void AddNewTimeRecord(IWebDriver driver)
        {
            //implicit wait

            //creating new time record

            Thread.Sleep(3000);
            
            try
            {

                IWebElement createnew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
                createnew.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("element not found");
            }

            Thread.Sleep(3000);
           
            try
            {
            
            IWebElement typecodedropdown = driver.FindElement(By.CssSelector("#TimeMaterialEditForm > div > div:nth-child(8) > div > span.k-widget.k-dropdown.k-header.text-box.single-line"));
            typecodedropdown.Click();
            }
            catch(Exception e)
            {
                Assert.Fail("element not found");
            }


            Thread.Sleep(3000);
            try
            {

                IWebElement timetypecode = driver.FindElement(By.CssSelector("#TypeCode_listbox > li:nth-child(2)"));
                timetypecode.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("element not found");
            }

            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("XYZ123");


            IWebElement desc = driver.FindElement(By.Id("Description"));
            desc.SendKeys("New record");



            IWebElement priceclick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceclick.Click();


            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("3000");

            Thread.Sleep(3000);

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Validating new record addition


            Thread.Sleep(3000);

            IWebElement navigateToLastPage = driver.FindElement(By.CssSelector("#tmsGrid > div.k-pager-wrap.k-grid-pager.k-widget > a.k-link.k-pager-nav.k-pager-last > span"));
            navigateToLastPage.Click();

            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 30);

            IWebElement recordCheck = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(recordCheck.Text == "XYZ123", "Record not added successfully");
                        
            
        }           
            
        public void EditTimeRecord(IWebDriver driver)
        {
            //Edit record

            Thread.Sleep(3000);

            IWebElement navigateToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigateToLastPage.Click();


           wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 30);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            wait.WaitToBeClickable(driver, "CssSelector", "#TimeMaterialEditForm > div > div:nth-child(8) > div > span.k-widget.k-dropdown.k-header.text-box.single-line > span", 30);

            IWebElement editTypeCodeDropDown = driver.FindElement(By.CssSelector("#TimeMaterialEditForm > div > div:nth-child(8) > div > span.k-widget.k-dropdown.k-header.text-box.single-line > span"));
            editTypeCodeDropDown.Click();

            wait.WaitToBeVisible(driver, "CssSelector", "#TypeCode_listbox > li:nth-child(1)", 30);

            IWebElement selectTypeCode = driver.FindElement(By.CssSelector("#TypeCode_listbox > li:nth-child(1)"));
            selectTypeCode.Click();

            IWebElement editCode = driver.FindElement(By.Id("Code"));
            editCode.Clear();
            editCode.SendKeys("ABC123");

            IWebElement materialDesc = driver.FindElement(By.Id("Description"));
            materialDesc.Clear();
            materialDesc.SendKeys("New material record");

            IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap.Click();

            
            IWebElement materialPrice = driver.FindElement(By.Id("Price"));
            materialPrice.Clear();

            IWebElement priceTagOverlap1 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTagOverlap1.Click();

            materialPrice.SendKeys("2000");

            IWebElement saveEditDataButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            saveEditDataButton.Click();

            //Validating the edited record

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 30);

            IWebElement navigate = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigate.Click();

            Thread.Sleep(3000);

            IWebElement checkrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That(checkrecord.Text == "ABC123", "Record not edited successfully");

            }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Deleting a record

            Thread.Sleep(3000);

            IWebElement navigateToLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigateToLastRecord.Click();

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 30);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            Thread.Sleep(2000);

            driver.SwitchTo().Alert().Accept();

            //Validating the delete action

            Thread.Sleep(3000);

            
            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (lastRecord.Text == "ABC123")
                { 
                Assert.Fail("Record not deleted");
            }
            else
            {
                Assert.Pass("Record deleted successfully");


            }

        }
    }
}
