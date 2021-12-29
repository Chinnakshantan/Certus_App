using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Certus_App.Helpers;
using Certus_App.PageObject;
using SeleniumNUnitExtentReport.Config;
using AventStack.ExtentReports;
using System.Threading;

namespace Certus_App.Steps
{
    [Binding]
    public sealed class CertusCalculatorSteps 
    {
      static  CertusCalculatorPage certusCalculatorPage;
        static CertusCalculatorSteps()
        {
            certusCalculatorPage = new CertusCalculatorPage();
        }
        private readonly ScenarioContext _scenarioContext;


        public CertusCalculatorSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I select '(.*)' state")]
        public void GivenISelectState(string state)
        {
            if(state == "California")
                ControlHelper.SelectDropdown("7",By.XPath(certusCalculatorPage.State));
            else if (state == "Florida")
                ControlHelper.SelectDropdown("13", By.XPath(certusCalculatorPage.State));
            else if (state == "Michigan")
                ControlHelper.SelectDropdown("29", By.XPath(certusCalculatorPage.State));
            else if (state == "New York")
                ControlHelper.SelectDropdown("42", By.XPath(certusCalculatorPage.State));
            else if (state == "Pennsylvania")
                ControlHelper.SelectDropdown("46", By.XPath(certusCalculatorPage.State));
            else if (state == "Texas")
                ControlHelper.SelectDropdown("52", By.XPath(certusCalculatorPage.State));


            Thread.Sleep(2000); 
            Reporting.Log(Status.Pass, state +" state is selected");
        }

        [When(@"I select random county from selected state")]
        public void WhenISelectCounty()
        {
            string county = ControlHelper.SelectRandomDropDown(By.XPath(certusCalculatorPage.County));
            

            Reporting.Log(Status.Pass, county +" county is selected");
        }

        [When(@"I press '(.*)' button in certus calculator")]
        public void WhenIPressButtonInCertusCalculator(string button)
        {
            if(button == "Search")
                ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.certusCalcSearchBtn));
            else if (button == "Next")
                ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.certusCalcNextBtn));
        }

        [When(@"I select '(.*)' in transaction type")]
        public void WhenISelectInTransactionType(string transactionType)
        {
            if (transactionType == "Refinance")
                ControlHelper.SelectDropdown("59", By.XPath(certusCalculatorPage.TransactionType));
        }

        [When(@"I select '(.*)' in Add Document")]
        public void WhenISelectInAddDocument(string addDocument)
        {
            if (addDocument == "Mortagage")
                ControlHelper.SelectDropdown("30:False", By.XPath(certusCalculatorPage.AddDocument));
        }

        [When(@"I press Add for Add Document")]
        public void WhenIPressAddForAddDocument()
        {
            ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.AddDoc));
        }


        [When(@"I enter Loan Amount as '(.*)'")]
        public void WhenIEnterLoanAmountAs(int loanAmnt)
        {
            ControlHelper.EnterText_In_Textbox(By.XPath(certusCalculatorPage.AddLoanAmount), loanAmnt.ToString());
        }

        [When(@"I enter no. of pages as '(.*)'")]
        public void WhenIEnternoofPagesAs(int pages)
        {
            ControlHelper.EnterText_In_Textbox(By.XPath(certusCalculatorPage.AddNoOfPages), pages.ToString());
            Thread.Sleep(2000);
        }

        [When(@"I scroll to '(.*)' button")]
        public void WhenIScrollToButton(string element)
        {
            if(element == "Next")
            ControlHelper.ScrollToElement(By.XPath(certusCalculatorPage.NextLoanInfoBtn));
        }

        [When(@"I press '(.*)' in Mortagage")]
        [When(@"I press '(.*)' in Loan information")]
        public void WhenIPressInLoanInformation(string button)
        {
            if (button == "Next")
                ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.NextLoanInfoBtn));
        }

        [When(@"I check for next button and press if exists")]
        public void WhenICheckForNextButtonAndPressIfExists()
        {
            bool nextPresent = ControlHelper.IsElementPresent(By.XPath(certusCalculatorPage.NextLoanInfoBtn));
            if(nextPresent == true)
            {
                ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.NextLoanInfoBtn));
            }
        }


        [Then(@"validate Transaction Id is generated")]
        public void ThenValidateTransactionIdIsGenerated()
        {
            string transacID = ControlHelper.GetText(By.XPath(certusCalculatorPage.TransactionId));
            if(transacID != null)
                Reporting.Log(Status.Pass, "Transaction Id is generated");
        }

        [Given(@"User is on Homepage")]
        public void GivenUserIsOnHomepage()
        {           
            
            Reporting.Log(Status.Info, "Move to element");
            
        }
      
        [When(@"I press 'Certus Calculator' in Home page")]
        public void WhenIPressInHomePage()
        {
            ControlHelper.ButtonClick(By.XPath(certusCalculatorPage.certusCalculator));
        }

    }
}
