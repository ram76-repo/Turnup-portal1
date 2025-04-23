using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Turnup_portal.pages;
using Turnup_portal.utilities;

namespace Turnup_portal.tests
{
    [TestFixture]
    public class TMpagetest : CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            //open chrome browser
            driver = new ChromeDriver();
            

            Loginpage loginobj = new Loginpage();
            loginobj.LoginActions(driver);

            Homepage homepageobj = new Homepage();
            homepageobj.NavigateToTMPage(driver);

        }

        [Test]
        public void CreateTimeTest()
        {
            TMpage tmPageObj = new TMpage();
            tmPageObj.AddNewTimeRecord(driver);

        }
        [Test]
        public void EditTimeTest()
        {
            TMpage tmPageObj = new TMpage();
            tmPageObj.EditTimeRecord(driver);

        }
        [Test]
        public void DeleteTimeTest()
        {
            TMpage tmPageObj = new TMpage();
            tmPageObj.DeleteTimeRecord(driver);
            
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}