using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.Admin
{
	public partial class AddUserPage
	{
		private string UserRoleDropdownXPath => "//select[@id = 'systemUser_userType']";
		private IWebElement UserRoleDropdown => _webDriver.FindElement(By.XPath(UserRoleDropdownXPath));
		private string EmployeeNameTextboxXPath => "//input[@id = 'systemUser_employeeName_empName']";
		private IWebElement EmployeeNameTextbox => _webDriver.FindElement(By.XPath(EmployeeNameTextboxXPath));
		private string UserNameTextboxXPath => "//input[@id = 'systemUser_userName']";
		private IWebElement UserNameTextbox => _webDriver.FindElement(By.XPath(UserNameTextboxXPath));
		private string StatusDropdownXPath => "//select[@id = 'systemUser_status']";
		private IWebElement StatusDropdown => _webDriver.FindElement(By.XPath(StatusDropdownXPath));
		private string PasswordTextboxXPath => "//input[@id = 'txtPassword ']";
		private IWebElement PasswordTextbox => _webDriver.FindElement(By.XPath(PasswordTextboxXPath));
		private string ConfirmPasswordTextboxXPath => "//input[@id = 'systemUser_confirmPassword']";
		private IWebElement ConfirmPasswordTextbox => _webDriver.FindElement(By.XPath(ConfirmPasswordTextboxXPath));
		private string SaveButtonXPath => "//input[@id = 'btnSave']";
		private IWebElement SaveButton => _webDriver.FindElement(By.XPath(SaveButtonXPath));
		private string CancelButtonXPath => "//input[@id = 'btnCancel']";
		private IWebElement CancelButton => _webDriver.FindElement(By.XPath(CancelButtonXPath));
	}
}
