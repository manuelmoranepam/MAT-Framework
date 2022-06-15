using OpenQA.Selenium;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.Home
{
	public partial class HomePage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public HomePage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		public bool IsHomePageHeadingDisplayed()
		{
			try
			{
				_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(HomePageHeadingXPath);

				var isDisplayed = HomePageHeading.Displayed;

				return isDisplayed;
			}
			catch
			{
				return false;
			}
		}

		public string GetHomePageHeading()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(HomePageHeadingXPath);

			var heading = HomePageHeading.Text;

			return heading;
		}
	}
}
