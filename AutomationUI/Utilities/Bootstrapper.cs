using System;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationUI.Utilities
{
	// configuração e injeção de dependência do WebDriver
	public class Bootstrapper : IDisposable
	{
		protected IWebDriver Driver { get; }

		public Bootstrapper(IObjectContainer objectContainer)
		{
			objectContainer.RegisterInstanceAs(new ChromeDriver(), typeof(IWebDriver));
			Driver = objectContainer.Resolve<IWebDriver>();
			Driver.Manage().Cookies.DeleteAllCookies();
			Driver.Manage().Window.Maximize();	
		}

		public void Dispose()
		{
			Driver?.Quit();
			Driver?.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
