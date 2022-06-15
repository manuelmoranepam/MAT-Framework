using OpenQA.Selenium;
using WebDriverClient.Interfaces;
using WebDriverClient.Extensions;

namespace OrangeHRMTestingSuite.PageObjects.Admin
{
	public partial class AddUserPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public AddUserPage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		//TODO: User Role Methods

		public void ClearEmployeeNameTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(EmployeeNameTextboxXPath);

			EmployeeNameTextbox.Clear();
		}

		public void EnterEmployeeName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException($"'{nameof(name)}' cannot be null or whitespace.", nameof(name));

			ClearEmployeeNameTextbox();

			EmployeeNameTextbox.SendKeys(name);
		}

		public string GetEmployeeNameFromTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(EmployeeNameTextboxXPath);

			var employeeName = EmployeeNameTextbox.GetAttribute("value");

			return employeeName;
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

		//TODO: Status Methods

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

		public void ClearConfirmPasswordTextbox()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(ConfirmPasswordTextboxXPath);

			ConfirmPasswordTextbox.Clear();
		}

		public void EnterConfirmPassword(string password)
		{
			if (string.IsNullOrWhiteSpace(password))
				throw new ArgumentException($"'{nameof(password)}' cannot be null or whitespace.", nameof(password));

			ClearConfirmPasswordTextbox();

			ConfirmPasswordTextbox.SendKeys(password);
		}

		public void ClickSaveButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(SaveButtonXPath);

			SaveButton.Click();

			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(SaveButtonXPath);
		}

		public void ClickCancelButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(CancelButtonXPath);

			CancelButton.Click();

			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(CancelButtonXPath);
		}
	}
}
