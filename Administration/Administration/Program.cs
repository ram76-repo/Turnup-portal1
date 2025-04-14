
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Admin
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("http://horse.industryconnect.io");

        //Finding username webelement

        IWebElement username = driver.FindElement(By.Id("UserName"));
        username.SendKeys("hari");

        //Finding password webelement

        IWebElement password = driver.FindElement(By.Id("Password"));
        password.SendKeys("123123");

        //click login button
        IWebElement login = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        login.Click();

        //check if the login is successful

        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if(helloHari.Text == "Hello hari!")
            {
            Console.WriteLine("Login successful");
        }
        else
        {
            Console.WriteLine("Login unsuccessful");
        }

        //Go to administration drop down

        IWebElement adminDropDown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        adminDropDown.Click();
        Thread.Sleep(5000);

        //go to time and material option
        IWebElement timeAndMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterial.Click();
        Thread.Sleep(1000);

        //click on create new button

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