using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Certus_App.Steps
{
    [Binding]
    public sealed class HomePage
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        String test_url = "https://dev.certusrecording.com/CertusWebsite/CertusCalculator/Calculator.aspx";
        String driverpath = Environment.CurrentDirectory + @"\Drivers\";

        IWebDriver driver;

        public HomePage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I launch '(.*)' driver")]
        public void GivenILaunchDriver(string drivername)
        {

            switch (drivername)
            {
                case "Chrome":
                    driver = new ChromeDriver(driverpath);
                    break;
                case "Firefox":
                    driver = new FirefoxDriver(driverpath);
                    break;
            }
            
            driver.Url = test_url;
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(20000);
        }


        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _scenarioContext.Pending();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _scenarioContext.Pending();
        }
    }
}
