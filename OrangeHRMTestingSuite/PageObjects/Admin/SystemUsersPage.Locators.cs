using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.Admin
{
	public partial class SystemUsersPage
	{
		private string AddUserButtonXPath => "//input[@id = 'btnAdd']";
		private IWebElement AddUserButton => _webDriver.FindElement(By.XPath(AddUserButtonXPath));
	}
}
