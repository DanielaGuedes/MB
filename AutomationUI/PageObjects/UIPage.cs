using System;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationUI.PageObjects
{
  	public class UIPage
	{
		private readonly IWebDriver _webDriver;
		private IWebElement _inputSearchBox;

		public UIPage(IWebDriver webDriver)
		{
			_webDriver = webDriver;
		}

		public void OpenbWebSite()
		{
			_webDriver.Navigate().GoToUrl("https://www.mercedes-benz.co.uk/");
			
		}

		public void SearchById(string id, string text)
		{
			_inputSearchBox = _webDriver.FindElement(By.Id(id));
			if (text != null)
			{
				_inputSearchBox.SendKeys(text);
			}
		}

		public string SearchByXPath(string xPath)
		{
			var text = _webDriver.FindElement(By.XPath(xPath));
			return text.ToString();
		}

		public void ChooseTheFirstItemOfList(string xPath)
		{
			_webDriver.FindElement(By.XPath(xPath)).Click();
		}
	}



}
