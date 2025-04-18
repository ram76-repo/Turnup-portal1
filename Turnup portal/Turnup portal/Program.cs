using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Turnup_portal.pages;

public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();

        Loginpage loginobj = new Loginpage();
        loginobj.LoginActions(driver);

        Homepage homepageobj = new Homepage();
        homepageobj.NavigateToTMPage(driver);

        TMpage addTimeRecord = new TMpage();
        addTimeRecord.AddNewTimeRecord(driver);

        TMpage editRecord = new TMpage();
        editRecord.EditTimeRecord(driver);

        TMpage deleteRecord = new TMpage();
        deleteRecord.DeleteTimeRecord(driver);


        
        

    }
}