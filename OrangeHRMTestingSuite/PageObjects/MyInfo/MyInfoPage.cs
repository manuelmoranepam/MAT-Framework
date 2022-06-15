using OpenQA.Selenium;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.MyInfo
{
	public partial class MyInfoPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		public MyInfoPage(IWebDriverClient webDriverClient)
		{
			_webDriverClient = webDriverClient;

			_webDriver = webDriverClient.GetInstanceOf();
		}

		public bool IsEditButtonDisplayed()
		{
			try
			{
				_webDriverClient.WebDriverWait
					.WaitForElementToBeVisible(EditButtonXPath);

				var isDisplayed = EditButton.Displayed;

				return isDisplayed;
			}
			catch
			{
				return false;
			}
		}

		public void ClickEditButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(EditButtonXPath);

			EditButton.Click();
		}

		//TODO: Nationality Dropdown Methods

		public bool IsSaveButtonDisplayed()
		{
			try
			{
				_webDriverClient.WebDriverWait
					.WaitForElementToBeVisible(SaveButtonXPath);

				var isDisplayed = SaveButton.Displayed;

				return isDisplayed;
			}
			catch
			{
				return false;
			}
		}

		public void ClickSaveButton()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(SaveButtonXPath);

			SaveButton.Click();
		}
	}
}
