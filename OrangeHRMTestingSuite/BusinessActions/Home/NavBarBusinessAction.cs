using OrangeHRMTestingSuite.PageObjects.Home;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.BusinessActions.Home
{
	internal class NavBarBusinessAction
	{
		private readonly IWebDriverClient _webDriverClient;

		private NavBarPage? _navBarPage;

		public NavBarBusinessAction(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;
		}

		public void NavigateToSystemUsersPage()
		{
			_navBarPage = new NavBarPage(_webDriverClient);

			_navBarPage.ClickAdminMenu();
			_navBarPage.HoverOverUserManagementSubMenu();
			_navBarPage.ClickUsersMenuOption();
		}

		public void NavigateToMyInfoPage()
		{
			_navBarPage = new NavBarPage(_webDriverClient);

			_navBarPage.ClickMyInfoMenuOption();
		}
	}
}
