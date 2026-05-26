using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace WindowsFormsApp1.Tests
{
    internal class Tests
    {
        //Here i run 2 tests 
        //The first is to find the search field and send the text "laptop" to it and then i quit the driver
        //The second test is to find the search button and click it and then i quit the driver
        [Test]
        public void search_field()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");

            IWebDriver driver = new ChromeDriver(options);

            driver.Url = "https://www.ebay.com/";

            IWebElement searchField = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/section/form/div[1]/div/div/input"));
            searchField.SendKeys("laptop");

            driver.Quit();
        }

        [Test]
        public void btn_search()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");

            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-logging");

            IWebDriver driver = new ChromeDriver(options);

            driver.Url = "https://www.ebay.com/";

            IWebElement searchBtn = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/section/form/div[2]/button"));
            searchBtn.Click();

            driver.Quit();
        }
    }
}
