using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.Extensions;

namespace Certus_App.Helpers
{
  public  class ControlHelper
    {
        public static IWebDriver _driver;
        public static IWebDriver driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
            }
        }
        private static string _browser;
        public static string Browser {
            get { return _browser; }
            set
            {
                _browser = value;
            }
        }
        private static string _website;
        public static string Website
        {
            get { return _website; }
            set
            {
                _website = value;
            }
        }

        public static string GetDir_Debug_Path()
        {
            string projectDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            return projectDir;
        }

        public static void LaunchBrowser(String browser)
        {
            String driverpath = ControlHelper.GetDir_Debug_Path();
            driverpath = driverpath + @"\Drivers";
            IWebDriver webDriver=null;
            switch (browser.ToLower())
            {
                case "chrome":
                    webDriver = new ChromeDriver(driverpath);
                    break;
                case "firefox":
                    webDriver = new FirefoxDriver(driverpath);
                    break;
            }

            webDriver.Url = ControlHelper.Website;
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            System.Threading.Thread.Sleep(5000);
            driver = webDriver;

        }
        public static void quitBrowser()
        {
            driver.Close();
            driver.Quit();            

        }

        public static void ScrollToElement(By locator)
        {
            IWebElement s = driver.FindElement(locator); 
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", s);
        }

        public static void ButtonClick(By locator)
        {
            driver.FindElement(locator).Click();
        }
        
        public static void Takescrrenshot(string filename = "Screen")
        {
            Screenshot screen = driver.TakeScreenshot();
            if (filename.Equals("Screen"))
            {
                filename = filename + DateTime.UtcNow.ToString("yyyy-MM--dd--mm-ss") + ".jpeg";
                screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
            }
            screen.SaveAsFile(filename, ScreenshotImageFormat.Jpeg);
        }
        public static void Entertext_In_TextBox_Javascript(By locator, string EnterText)
        {
            IWebElement element = driver.FindElement(locator);
            
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            
            
            je.ExecuteScript("arguments[0].value='" + EnterText + "';", element);
            Thread.Sleep(1000);
            je.ExecuteScript("arguments[0].click();", element);
        }
        public static void EnterText_In_Textbox(By locator,string EnterText)
        {
          
            driver.FindElement(locator).SendKeys(EnterText);
        }
        public static string GetText(By locator)
        {
           return driver.FindElement(locator).Text;
        }
        public static void SelectDropdown(By locator,int index)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByIndex(index);
             
        }
        public static void SelectDropdown(By locator, string visibletext)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByText(visibletext);
        }
        public static void SelectDropdown(string value,By locator)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            selectElement.SelectByValue(value);
        }
        public static string SelectRandomDropDown(By locator)
        {
            SelectElement selectElement = new SelectElement(driver.FindElement(locator));
            IList<IWebElement> counties = selectElement.Options;

            Random random = new Random();
            int randomIndex = random.Next(counties.Count);
            selectElement.SelectByText(counties.ElementAt(randomIndex).Text);
            return counties.ElementAt(randomIndex).Text;
        }
        public static void NavigateToURL(string Url)
        {
           driver.Navigate().GoToUrl(Url);
        }
        public static bool IsElementPresent(By Locator)
        {
            try
            {
                return driver.FindElements(Locator).Count == 1;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static ReadOnlyCollection<IWebElement> GetElementList(By Locator)
        {
           return driver.FindElements(Locator);
        }

        public static string GetAttributeValue(By Locator,string attributeValue)
        {
           return driver.FindElement(Locator).GetAttribute(attributeValue);
        }

        public static bool IsElementEnable(By Locator)
        {
            return driver.FindElement(Locator).Enabled;
        }
    }
}
