using OpenQA.Selenium;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.Login
{
	public partial class LoginPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public LoginPage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		public void ClearUserNameTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(UserNameTextboxXPath);
			
			UserNameTextbox.Clear();
		}

		public void EnterUserName(string username)
		{
			if (string.IsNullOrWhiteSpace(username))
				throw new ArgumentException($"'{nameof(username)}' cannot be null or whitespace.", nameof(username));

			ClearUserNameTextbox();

			UserNameTextbox.SendKeys(username);
		}

		public string GetUserNameFromTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(UserNameTextboxXPath);

			var username = UserNameTextbox.GetAttribute("value");

			return username;
		}

		public void ClearPasswordTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(PasswordTextboxXPath);

			PasswordTextbox.Clear();
		}

		public void EnterPassword(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));

			ClearPasswordTextbox();

			PasswordTextbox.SendKeys(password);
		}

		public void ClickLoginButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(LoginButtonXPath);

			LoginButton.Click();
		}
	}
}
