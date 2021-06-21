using BoDi;
using System;
using TechTalk.SpecFlow;
using AutomationUI.Utilities;
using AutomationUI.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AutomationUI.Steps
{
    [Binding]
    public class AccessWebsiteSteps : Bootstrapper
    {
        private readonly UIPage mbPage;

        public AccessWebsiteSteps(IObjectContainer objectContainer) : base(objectContainer)
        {
            mbPage = new UIPage(this.Driver);
        }

        [Given(@"I navigate to the Mercedes-benz home page")]
        public void GivenINavigateToTheMercedes_BenzHomePage()
        {
            mbPage.OpenbWebSite();
        }

        [Given(@"I select one model (.*)")]
        public void GivenISelectOneModel(string allModels)
        {                 
            if (mbPage.SearchByXPath("//h2['DAIMLER GROUP (UK) uses cookies for various purpos']") != "")
            {
                mbPage.ChooseTheFirstItemOfList("//button[@id='uc-btn-accept-banner']");
            }
            //mbPage.List(allModels);
        }

        [When(@"I mouse over the car model (.*) to click to Build Your Car")]
        public void WhenIMouseOverTheCarModelToClickToBuildYourCar(string carModel)
        {

        }

        [Then(@"I can choose the Fuel type (.*) to validate models price")]
        public void ThenICanChooseTheFuelTypeToValidateModelsPrice(string fuelType)
        {

        }
    }
}
