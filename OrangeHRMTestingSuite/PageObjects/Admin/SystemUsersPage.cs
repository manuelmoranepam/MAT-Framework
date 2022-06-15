using OpenQA.Selenium;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.Admin
{
	public partial class SystemUsersPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public SystemUsersPage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		public void ClickAddUserButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(AddUserButtonXPath);

			AddUserButton.Click();
		}
	}
}
