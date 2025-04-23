using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Turnup_portal.utilities;

namespace Turnup_portal.pages
{
    public class TMpage
    {
        public void AddNewTimeRecord(IWebDriver driver)
        {
            //creating new time record

            Thread.Sleep(10000);

            IWebElement createnew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createnew.Click();

            Thread.Sleep(15000);

            IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            typecodedropdown.Click();

            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 30);

            IWebElement timetypecode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timetypecode.Click();

                                   
            IWebElement code = driver.FindElement(By.Id("Code"));
            code.SendKeys("XYZ123");
                    

            IWebElement desc = driver.FindElement(By.Id("Description"));
            desc.SendKeys("New record");

            

            IWebElement priceclick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceclick.Click();

            wait.WaitToBeVisible(driver, "Id", "Price", 30);

            IWebElement price = driver.FindElement(By.Id("Price"));
            price.SendKeys("3000");

            wait.WaitToBeClickable(driver, "Id", "SaveButton", 30);

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Validating new record addition

          
            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 30);

            IWebElement navigateToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigateToLastPage.Click();

            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]", 20);

            IWebElement recordCheck = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

           
            if (recordCheck.Text == "XYZ123")
            {
                Assert.Pass("Record added successfully");
            }
            else
            {
                Assert.Fail("Record not added");
            }
        }
        public void EditTimeRecord(IWebDriver driver)
        {
            //Edit record

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]/span", 30);

            IWebElement navigateToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigateToLastPage.Click();


            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 20);

            IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]", 20);

            IWebElement editTypeCodeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
            editTypeCodeDropDown.Click();

            
            IWebElement selectTypeCode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_option_selected\"]"));
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

            
            IWebElement checkrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (checkrecord.Text == "ABC123")
            {
                Assert.Pass("Record edited successfully");
            }
            else
            {
                Assert.Fail("Edit unsuccessful");
            }

        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Deleting a record

            IWebElement navigateToLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            navigateToLastRecord.Click();

            wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 30);

            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            
            driver.SwitchTo().Alert().Accept();

            //Validating the delete action

            wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[1]/span", 30);

            IWebElement first = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[1]/span"));
            first.Click();

            IWebElement last = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            last.Click();

            IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            if (lastRecord.Text == "ABC123")
            {
                Assert.Pass("Record deleted successfully");
            }
            else
            {
                Assert.Fail("Record deletion unsuccessful");
            }
        }
    }
}
