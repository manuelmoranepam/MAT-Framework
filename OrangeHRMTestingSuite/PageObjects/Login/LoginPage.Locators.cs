using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.Login
{
	public partial class LoginPage
	{
		private string UserNameTextboxXPath => "//input[@id = 'txtUsername']";
		private IWebElement UserNameTextbox => _webDriver.FindElement(By.XPath(UserNameTextboxXPath));
		private string PasswordTextboxXPath => "//input[@id = 'txtPassword']";
		private IWebElement PasswordTextbox => _webDriver.FindElement(By.XPath(PasswordTextboxXPath));
		private string LoginButtonXPath => "//input[@id = 'btnLogin']";
		private IWebElement LoginButton => _webDriver.FindElement(By.XPath(LoginButtonXPath));
	}
}
