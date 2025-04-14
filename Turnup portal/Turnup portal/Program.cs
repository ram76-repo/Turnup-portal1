using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

        //login validation

        IWebElement username = driver.FindElement(By.Id("UserName"));
        username.SendKeys("hari");

        IWebElement password = driver.FindElement(By.Id("Password"));
        password.SendKeys("123123");

        IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        login.Click();

        //navigating to TM page

        IWebElement admindropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        admindropdown.Click();

        IWebElement timeandelement = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeandelement.Click();
        Thread.Sleep(3000);

        //creating new time record

        IWebElement createnew = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createnew.Click();
        Thread.Sleep(3000);

        IWebElement typecodedropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
        typecodedropdown.Click();
        Thread.Sleep(2000);

        IWebElement timetypecode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timetypecode.Click();

        IWebElement code = driver.FindElement(By.Id("Code"));
        code.SendKeys("XYZ123");

        IWebElement desc = driver.FindElement(By.Id("Description"));
        desc.SendKeys("New record");

        IWebElement priceclick = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceclick.Click();

        IWebElement price = driver.FindElement(By.Id("Price"));
        price.SendKeys("3000");

        IWebElement saveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
        saveButton.Click();
        Thread.Sleep(3000);
                
        IWebElement navigateToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        navigateToLastPage.Click();
        Thread.Sleep(2000);

        IWebElement recordCheck = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

        if (recordCheck.Text == "XYZ123")
            {
            Console.WriteLine("Record added successfully");
            }
        else
        {
            Console.WriteLine("Record not added");
        }

        //Edit record

        IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        editButton.Click();

        IWebElement editTypeCodeDropDown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]"));
        editTypeCodeDropDown.Click();
        Thread.Sleep(3000);

        IWebElement editCode = driver.FindElement(By.Id("Code"));
        editCode.Clear();
        editCode.SendKeys("ABC123");

        IWebElement materialDesc = driver.FindElement(By.Id("Description"));
        materialDesc.Clear();
        materialDesc.SendKeys("New material record");

        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();
        Thread.Sleep(1000);

        IWebElement materialPrice = driver.FindElement(By.Id("Price"));
        materialPrice.Clear();

        IWebElement priceTagOverlap1 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap1.Click();
        Thread.Sleep(1000);
        materialPrice.SendKeys("2000");              

        IWebElement saveEditDataButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
        saveEditDataButton.Click();
        Thread.Sleep(2000);

        //Validating the edited record

        IWebElement navigate = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        navigate.Click();

        IWebElement checkrecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        
        if (checkrecord.Text == "ABC123")
        {
            Console.WriteLine("Record edited successfully");
        }
        else
        {
            Console.WriteLine("Edit unsuccessful");
        }

        //Deleting a record

        IWebElement navigateToLastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        navigateToLastRecord.Click();

        Thread.Sleep(2000);

        IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        deleteButton.Click();
        Thread.Sleep(2000);

        driver.SwitchTo().Alert().Accept();

        //Validating the delete action

        Thread.Sleep(2000);

        IWebElement lastRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        Console.WriteLine(lastRecord.Text);

        if (lastRecord.Text == "ABC123")
        {
          Console.WriteLine("Delete unsuccessful");
        }
        else
        {
         Console.WriteLine("Record deleted successfully");
        }

    }
}