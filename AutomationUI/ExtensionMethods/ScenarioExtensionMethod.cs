using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Bindings;

namespace AutomationUI.ExtensionMethods
{
	public static class ScenarioExtensionMethod
	{
		private static ExtentTest CreateScenario(ExtentTest extent, StepDefinitionType stepDefinitionType)
		{
			var scenarioStepContext = ScenarioStepContext.Current.StepInfo.Text;

            return stepDefinitionType switch
            {
                StepDefinitionType.Given => extent.CreateNode<Given>(scenarioStepContext),
                StepDefinitionType.Then => extent.CreateNode<Then>(scenarioStepContext),
                StepDefinitionType.When => extent.CreateNode<When>(scenarioStepContext),
                _ => throw new ArgumentOutOfRangeException(nameof(stepDefinitionType), stepDefinitionType, null),
            };
        }

        private static void CreateScenarioFailOrError(ExtentTest extent, StepDefinitionType stepDefinitionType, ScenarioContext scenarioContext)
		{
			var error = scenarioContext.TestError;

			if (error.InnerException == null)
			{
				CreateScenario(extent, stepDefinitionType).Error(error.Message);
			}
			else
			{
				CreateScenario(extent, stepDefinitionType).Fail(error.InnerException);
			}
		}

        public static void StepDefinitionGiven(this ExtentTest extent, ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError == null)
				CreateScenario(extent, StepDefinitionType.Given);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.Given, scenarioContext);
		}

         public static void StepDefinitionWhen(this ExtentTest extent, ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError == null)
				CreateScenario(extent, StepDefinitionType.When);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.When, scenarioContext);
		}

        public static void StepDefinitionThen(this ExtentTest extent, ScenarioContext scenarioContext)
		{
			if (scenarioContext.TestError == null)
				CreateScenario(extent, StepDefinitionType.Then);
			else
				CreateScenarioFailOrError(extent, StepDefinitionType.Then, scenarioContext);
		}
	}
}

