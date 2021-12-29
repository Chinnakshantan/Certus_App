using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;
using Certus_App.Helpers;
using System.Configuration;

namespace SeleniumNUnitExtentReport.Config
{

    [Binding]
    public class Reporting : TechTalk.SpecFlow.Steps
    {
        private static ScenarioContext _scenarioContext;
        private static FeatureContext _featureContext;
        private static ExtentReports _extentReports;
        private static ExtentHtmlReporter _extentHtmlReporter;
        private static ExtentTest _feature;
        public static ExtentTest _scenario;
        public static ExtentTest step;
        [BeforeTestRun]
        public static void BeforeTestRun()
        {

            

            var projectDir = ControlHelper.GetDir_Debug_Path();
            projectDir = projectDir + @"\Reports\";
            _extentHtmlReporter = new ExtentHtmlReporter(projectDir);

            _extentReports = new ExtentReports();

            _extentReports.AttachReporter(_extentHtmlReporter);

            

        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            _extentReports.Flush();
        }
        [BeforeFeature]
        public static void BeforeFeatureStarts(FeatureContext featurecontext)
        {
            if (null != featurecontext)
            {
                _feature = _extentReports.CreateTest<Feature>(featurecontext.FeatureInfo.Title, featurecontext.FeatureInfo.Description);
            }
        }
        [BeforeScenario]
        public static void BeforeScenarioStarts(ScenarioContext scenarioContext)
        {
            if (null != scenarioContext)
            {
                _scenarioContext = scenarioContext;
                _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            }
            var browser = ConfigurationManager.AppSettings.Get("Browser");
            ControlHelper.Website = ConfigurationManager.AppSettings.Get("WebsiteUrl");

            ControlHelper.Browser = browser;
            ControlHelper.LaunchBrowser(ControlHelper.Browser);
        }
        [AfterScenario]
        public static void AfterScenario(ScenarioContext scenarioContext)
        {
            ControlHelper.quitBrowser();
        }
        [BeforeStep]
        public static void BeforeStep()
        {
            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    CreateNodeBefore<Given>();
                    break;
                case ScenarioBlock.When:
                    CreateNodeBefore<When>();
                    break;
                case ScenarioBlock.Then:
                    CreateNodeBefore<Then>();
                    break;
                default:
                    CreateNodeBefore<And>();
                    break;

            }
        }
        [AfterStep]
        public static void AfterEachStep()
        {

            ScenarioBlock scenarioBlock = _scenarioContext.CurrentScenarioBlock;
            switch (scenarioBlock)
            {
                case ScenarioBlock.Given:
                    //if(_scenarioContext.TestError!=null)
                    //{
                    //    _scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    //}
                    //else
                    //{
                    //    _scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                    //}
                    CreateNode<Given>();
                    break;
                case ScenarioBlock.When:
                    //if (_scenarioContext.TestError != null)
                    //{
                    //    _scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    //}
                    //else
                    //{
                    //    _scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                    //}
                    CreateNode<When>();
                    break;
                case ScenarioBlock.Then:
                    //if (_scenarioContext.TestError != null)
                    //{
                    //    _scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    //}
                    //else
                    //{
                    //    _scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                    //}
                    CreateNode<Then>();
                    break;
                default:
                    //if (_scenarioContext.TestError != null)
                    //{
                    //    _scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace);
                    //}
                    //else
                    //{
                    //    _scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
                    //}
                    CreateNode<And>();
                    break;

            }
            _extentReports.Flush();
        }
        /// <summary>
        /// The logging of test results to Extend report
        /// </summary>        

        public static void Log(Status status,string Log_text)
        {
            step.Log(status, Log_text);
        }
        public static void CreateNode<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                var projectDir = ControlHelper.GetDir_Debug_Path();
                projectDir = projectDir + @"\Screenshots\";
                string name = projectDir + _scenarioContext.ScenarioInfo.Title.Replace(" ", "") + ".jpeg";
                ControlHelper.Takescrrenshot(name);
              _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message + "\n" + _scenarioContext.TestError.StackTrace).AddScreenCaptureFromPath(name);
            }
            else
            {
               //  _scenario.CreateNode<T>(ScenarioStepContext.Current.StepInfo.Text).Pass("");
            }
        }

        public static void CreateNodeBefore<T>() where T : IGherkinFormatterModel
        {
            if (_scenarioContext.TestError != null)
            {
                
                step = _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else
            {
                step = _scenario.CreateNode<T>(_scenarioContext.StepContext.StepInfo.Text);
            }
        }
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        //  [BeforeTestRun]
        public static void InitializeReport()
        {
            var projectDir = ControlHelper.GetDir_Debug_Path();
            var htmlReporter = new ExtentHtmlReporter(projectDir);

            extent = new ExtentReports();
            //Create a node for the specific scenario
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

            //Set new value of the Scenario counter to Feature context
            ScenarioContext.Current.Add("StepCount", 1);
            FeatureContext.Current["ScenarioCount"] = FeatureContext.Current.Get<int>("ScenarioCount") + 1;
            FeatureContext.Current["StepFail"] = 0;
            extent.AttachReporter(htmlReporter);
        }
        //  [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }
        //  [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object TestResult = getter.Invoke(sc, null);
            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
        //  [BeforeFeature]
        public static void BeforeFeature(FeatureContext featurecontext)
        {
            featureName = extent.CreateTest(featurecontext.FeatureInfo.Title);
        }
    }
}

