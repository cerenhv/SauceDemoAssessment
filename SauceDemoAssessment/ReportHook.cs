using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.IO;
using AventStack.ExtentReports;

namespace SauceDemoAssessment
{
    [Binding]
    public class ReportHook : TechTalk.SpecFlow.Steps
    {
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports extentReport;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(SetUpReportPath());
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = "SauceDemo Automation Test Report";
            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReporter);
        }
        [AfterTestRun]
        public static void TearDownReport()
        {
            extentReport.Flush();
        }
        [AfterStep]
        public void InsertReportingSteps(ScenarioContext sc)
        {
            var stepType = sc.StepContext.StepInfo.StepDefinitionType.ToString();

            if (sc.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text);
            }
            if (sc.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "When")
                    scenario.CreateNode<When>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
                if (stepType == "And")
                    scenario.CreateNode<And>(sc.StepContext.StepInfo.Text).Fail(sc.TestError.Message);
            }
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extentReport.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void InitializeScenario(FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void CleanUp(ScenarioContext scenarioContext)
        {
            //to check if we missed to implement any step
            string resultOfImplementation = scenarioContext.ScenarioExecutionStatus.ToString();

            //Pending Status
            if (resultOfImplementation == "UndefinedStep")
            {
                // Log.StepNotDefined();
            }
        }

        public static string SetUpReportPath()
        {
            string curDir = Directory.GetCurrentDirectory().Split(new string[] { "bin" }, StringSplitOptions.None)[0];
            string reportDir = Path.Combine(curDir, "Report");
            if (!Directory.Exists(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            string path = Path.Combine(reportDir, "SauceDemoReport.hmtl");
            return path;
        }
    }
}
