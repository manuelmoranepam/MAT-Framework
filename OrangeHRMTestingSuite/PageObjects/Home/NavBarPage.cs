using OpenQA.Selenium;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.Home
{
	public partial class NavBarPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public NavBarPage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		public void ClickAdminMenu()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(AdminMenuXPath);

			AdminMenu.Click();
		}

		public void HoverOverUserManagementSubMenu()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(UserManagementSubmenuXPath);

			UserManagementSubmenu.HoverOver(_webDriver);
		}

		public void ClickUsersMenuOption()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(UsersMenuOptionXPath);

			UsersMenuOption.Click();
		}

		public void ClickMyInfoMenuOption()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(MyInfoMenuOptionXPath);

			MyInfoMenuOption.Click();
		}
	}
}
