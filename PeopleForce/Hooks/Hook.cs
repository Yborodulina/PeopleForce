using System;
using OpenQA.Selenium;
using PeopleForce.Methods;
using PlanA.Web.Core;
using PlanA.Web.Core.Core.WebDriver;
using PlanA.Web.Core.Extensions.Selenium;
using PlanA.Web.Core.Helper;
using SharpAvi;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow.Tracing;

namespace PeopleForce.Hooks
{
    [Binding]
    public class Hooks

    {
        private Recorder _recorder;
        private readonly ISpecFlowOutputHelper _specFlowOutputHelper;

        public Hooks(ISpecFlowOutputHelper specFlowOutputHelper)
        {
            _specFlowOutputHelper = specFlowOutputHelper;
        }

        [BeforeFeature]
        public static void DeleteOldTestResults(FeatureContext featureContext)
        {
            FileHelper.DeleteFolder(Path.Combine(Directory.GetCurrentDirectory(), "PageSource",
                featureContext.FeatureInfo.Title.ToIdentifier()));
            FileHelper.DeleteFolder(Path.Combine(Directory.GetCurrentDirectory(), "Screenshots",
                featureContext.FeatureInfo.Title.ToIdentifier()));
            FileHelper.DeleteFolder(Path.Combine(Directory.GetCurrentDirectory(), "Video",
                featureContext.FeatureInfo.Title.ToIdentifier()));
        }

        [BeforeFeature(Order = 0)]
        public static void BeforeFeature()
        {
            var loginMethod = new LoginMethods();

            var testType = typeof(WebDriver);

            if (testType == null) throw new Exception("testType is null");

            if (TestConfig.Browser == null) throw new Exception("TestConfig is null");

            ConfigureDriver();
            Driver.GoToPage(TestConfig.BaseUrl.ToString());
            loginMethod.Login();
        }

        [BeforeScenario]
        public void BeforeScenarios(FeatureContext featureContext, ScenarioInfo scenarioInfo)
        {
            if (TestConfig.VideoRecording)
            {
                var fileNameBase = $"{scenarioInfo.Title.ToIdentifier()}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
                _recorder = new Recorder(new RecorderParams(featureContext.FeatureInfo.Title.ToIdentifier(),
                    $"{fileNameBase}.avi", 1, CodecIds.Uncompressed, 2));
            }
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            Driver.Close();
        }

        [AfterScenario]
        public void AfterScenario(FeatureContext featureContext, ScenarioInfo scenarioInfo,
            ScenarioContext scenarioContext)
        {
            if (TestConfig.VideoRecording)
            {
                _recorder.Dispose();
                _specFlowOutputHelper.AddAttachment(_recorder.FilePath());
            }

            if (scenarioContext.TestError != null)
            {
                _specFlowOutputHelper.AddAttachment(ScreenshotMaker.TakeScreenshot(Driver.Instance, featureContext,
                    scenarioInfo));
                Driver.Instance.RefreshPage();
            }
        }

        private static void ConfigureDriver()
        {
            var asm = typeof(WebDriver).Assembly;
            var browser = TestConfig.Browser;
            var type = asm.GetType($"OpenQA.Selenium.{browser}.{browser}Driver");
            Driver.InitWebDriver(type);
            Driver.Instance.Manage().Window.Maximize();
            Driver.Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(TestConfig.ElementTimeout);
            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TestConfig.ElementTimeout);
        }
    }
}