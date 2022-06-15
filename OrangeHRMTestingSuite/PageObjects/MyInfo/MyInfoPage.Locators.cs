using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.MyInfo
{
	public partial class MyInfoPage
	{
		private string EditButtonXPath => "//input[@id = 'btnSave'][@value = 'Edit']";
		private IWebElement EditButton => _webDriver.FindElement(By.XPath(EditButtonXPath));
		private string NationalityDropdownXPath => "//select[@id = 'personal_cmbNation']";
		private IWebElement NationalityDropdown => _webDriver.FindElement(By.XPath(NationalityDropdownXPath));
		private string SaveButtonXPath => "//input[@id = 'btnSave'][@value = 'Save']";
		private IWebElement SaveButton => _webDriver.FindElement(By.XPath(SaveButtonXPath));
	}
}
