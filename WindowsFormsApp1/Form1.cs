using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        IWebDriver driver;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Here i got an error because my current google version is 148 and the avalible package is 149,so i didn't
                //So i used this technique i found it online down below and i downloaded a package called WebDriverManager and i used it to download the matching version of the driver for my google version and it worked fine without any error
                new DriverManager().SetUpDriver(new ChromeConfig(), "MatchingBrowser");           
                driver = new ChromeDriver();

                driver.Manage().Window.Maximize();
                driver.Url = "https://www.ebay.com/";
                // I get error finding the elemnt by the id gh-ac so i chose to use xpath and not .ById
                IWebElement searchField = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/section/form/div[1]/div/div/input"));
                IWebElement searchBtn = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/header/section/form/div[2]/button"));
                //here i clear the field from any input text and then i send the text from the text box to the search field and click the search button
                searchField.Clear();
                searchField.SendKeys(textBox1.Text);
                searchBtn.Click();
                //i take the current url and simply append it in the richtextbox for hisotry and also i put it in the text box 2 to show the user the current url
                string currentUrl = driver.Url;
                textBox2.Text = currentUrl;
                richTextBox1.AppendText(currentUrl + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened scraping the web page.The error is:  " + ex.Message);
                //Here i clode the driver in case of an exception to avoid leaving the browser open so we don't have memory leaks
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }


            }
        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                driver.Navigate().Back();
                //Here i just clear the fields like the task asked for
                textBox1.Clear();
                textBox2.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error happened navigating back.The error is:  " + ex.Message);
                if (driver != null)
                {
                    driver.Quit();
                    driver = null;
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
                MessageBox.Show("Browser closed successfully...");
            }
            else
                {
                    MessageBox.Show("No open browser found.");
            }
        }
    }
}
