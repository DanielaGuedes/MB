using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AutomationUI.ExtensionMethods;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace AutomationUI.Utilities
{
    [Binding]
    public class Hooks
    {
		private static ExtentTest _feature;
		private static ExtentTest _scenario;
		private static ExtentReports _extent;
		private static readonly string PathReport = $"{AppDomain.CurrentDomain.BaseDirectory}index.html";

		[BeforeTestRun]
		public static void ConfigureReport()
		{
			var reporter = new ExtentHtmlReporter(PathReport);
			_extent = new ExtentReports();
			_extent.AttachReporter(reporter);
		}

		[BeforeFeature]
        public static void CreateFeature(FeatureContext featurecontext)
		{
			_feature = _extent.CreateTest<Feature>(featurecontext.FeatureInfo.Title);
		}

		[BeforeScenario]
        public static void CreateScenario(ScenarioContext scenarioContext)
		{
			_scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
		}

		[AfterStep]
		public static void InsertReportingSteps(ScenarioContext scenarioContext)
		{
			switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
			{
				case StepDefinitionType.Given:
					_scenario.StepDefinitionGiven(scenarioContext);
					break;

				case StepDefinitionType.Then:
					_scenario.StepDefinitionThen(scenarioContext);
					break;

				case StepDefinitionType.When:
					_scenario.StepDefinitionWhen(scenarioContext);
					break;
			}
		}

		[AfterTestRun]
		public static void FlushExtent()
		{
			_extent.Flush();
			System.Diagnostics.Process.Start(PathReport);
		}
	}
}
