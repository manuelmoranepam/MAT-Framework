using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.Home
{
	public partial class NavBarPage
	{
		private string AdminMenuXPath => "//a[@id = 'menu_admin_viewAdminModule']";
		private IWebElement AdminMenu => _webDriver.FindElement(By.XPath(AdminMenuXPath));
		private string UserManagementSubmenuXPath => "//a[@id = 'menu_admin_UserManagement']";
		private IWebElement UserManagementSubmenu => _webDriver.FindElement(By.XPath(UserManagementSubmenuXPath));
		private string UsersMenuOptionXPath => "//a[@id = 'menu_admin_viewSystemUsers']";
		private IWebElement UsersMenuOption => _webDriver.FindElement(By.XPath(UsersMenuOptionXPath));
		private string MyInfoMenuOptionXPath => "//a[@id = 'menu_pim_viewMyDetails']";
		private IWebElement MyInfoMenuOption => _webDriver.FindElement(By.XPath(MyInfoMenuOptionXPath));
	}
}
