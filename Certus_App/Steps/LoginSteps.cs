using AventStack.ExtentReports;
using Certus_App.Helpers;
using Certus_App.PageObject;
using OpenQA.Selenium;
using SeleniumNUnitExtentReport.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Certus_App.Steps
{

    [Binding]
    public sealed class LoginSteps
    {
        static LoginPage loginPage;
        static CertusCalculatorPage homePage;
        static LoginSteps()

        {
            loginPage = new LoginPage();
            homePage = new CertusCalculatorPage();
        }
        private readonly ScenarioContext _scenarioContext;

        IWebDriver driver;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"User login to certus calculator as 'client'")]
        public void GivenILoginToCetrusCalculatorAs()
        {
            string clientUsername = ConfigurationManager.AppSettings.Get("ClientUsername");
            string clientPassword = ConfigurationManager.AppSettings.Get("ClientPassword");
            ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterUserId), clientUsername);
            ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterPassword), clientPassword);
            ControlHelper.ButtonClick(By.XPath(loginPage.SignInBtn));

            Reporting.Log(Status.Fail, "Sign in button clicked");
        }

        [Then(@"Validate login page is successful")]
        public void ThenValidateLoginPageIsSuccessful()
        {
            Thread.Sleep(5000);
             string userName = ControlHelper.GetText(By.XPath(homePage.userNameText));
            if (userName == "Test")
                Reporting._scenario.Log(AventStack.ExtentReports.Status.Pass, "Sign in successful");


           
        }


        [Given(@"I login certus using 'Invalid credentials'")]
        public void GivenILogincertususingInvalid()

        {
            string BadUsername = "BadUsername";
            string BadPassword = "BadPassword";
            ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterUserId), BadUsername);
            ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterPassword), BadPassword);
            ControlHelper.ButtonClick(By.XPath(loginPage.SignInBtn));


            Reporting._scenario.Log(AventStack.ExtentReports.Status.Pass, "User should'nt be able to login");
        }

        [Then(@"Validate unsuccessful login")]
        public void Validateunsuccessfullogin()
        {
            string incorrectLoginMessage = ControlHelper.GetText(By.XPath(loginPage.ErrorLoginText));
            if(incorrectLoginMessage == "Incorrect Username or Password.")
                Reporting._scenario.Log(AventStack.ExtentReports.Status.Pass, "Test Passed");

            
        }
    }
    }
