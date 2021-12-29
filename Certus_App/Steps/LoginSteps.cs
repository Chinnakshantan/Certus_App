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
            try
            {
                string clientUsername = ConfigurationManager.AppSettings.Get("ClientUsername");
                string clientPassword = ConfigurationManager.AppSettings.Get("ClientPassword");
                ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterUserId), clientUsername);
                ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterPassword), clientPassword);
                ControlHelper.ButtonClick(By.XPath(loginPage.SignInBtn));
                Reporting.Log(Status.Pass, "Sign in button clicked");
            }
            catch (Exception e)
            {
                Reporting.Log(Status.Fail, e.ToString());
            }


        }

        [Then(@"Validate login page is successful")]
        public void ThenValidateLoginPageIsSuccessful()
        {
            
            string userName = ControlHelper.GetText(By.XPath(homePage.userNameText));
            if (userName == "Test")
            {
                Reporting.Log(Status.Pass, "Sign in successful with user 'Test'");
            }                
            else
            {
                Reporting.Log(Status.Fail, "Sign in failed");
            }
                



        }


        [Given(@"I login certus using 'Invalid credentials'")]
        public void GivenILogincertususingInvalid()
        {
            try
            {
                string BadUsername = "BadUsername";
                string BadPassword = "BadPassword";
                ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterUserId), BadUsername);
                ControlHelper.EnterText_In_Textbox(By.XPath(loginPage.EnterPassword), BadPassword);
                ControlHelper.ButtonClick(By.XPath(loginPage.SignInBtn));
                Reporting.Log(Status.Pass, "User should'nt be able to login");
            }
            catch(Exception e)
            {
                Reporting.Log(Status.Fail, e.ToString());
            }
            
        }

        [Then(@"Validate unsuccessful login")]
        public void Validateunsuccessfullogin()
        {
            string incorrectLoginMessage = ControlHelper.GetText(By.XPath(loginPage.ErrorLoginText));
            if(incorrectLoginMessage == "Incorrect Username or Password.")
                Reporting.Log(Status.Pass, "'Incorrect username and password' is displayed");
            else
                Reporting.Log(Status.Fail, "Unable to find 'Incorrect username and password' text");
        }
    }
    }
