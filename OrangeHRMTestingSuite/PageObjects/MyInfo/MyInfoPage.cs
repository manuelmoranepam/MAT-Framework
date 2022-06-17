using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OrangeHRMTestingSuite.Helpers;
using WebDriverClient.Extensions;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.PageObjects.MyInfo
{
	public partial class MyInfoPage
	{
		private readonly IWebDriverClient _webDriverClient;
		private readonly IWebDriver _webDriver;

		private SelectElement _selectElement;

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

		public void SelectNationality()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var index = RandomDataHelper.GetRandomIndex(1, _selectElement.Options.Count);

			_selectElement.SelectByIndex(index);
		}

		public void SelectNationality(int index)
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			_selectElement.SelectByIndex(index);
		}

		public void SelectNationality(string nationality)
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var optionText = _selectElement.Options
				.First(option => option.Text == nationality)
				.Text;

			_selectElement.SelectByText(optionText);
		}

		public void SelectNationalityByPartial(string partialNationality)
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var optionText = _selectElement.Options
				.First(option => option.Text.Contains(partialNationality))
				.Text;

			_selectElement.SelectByText(optionText);
		}

		public string GetSelectedNationality()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var selectedOption = _selectElement.SelectedOption.Text;

			return selectedOption;
		}

		public int GetNationalityOptionsCount()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var count = _selectElement.Options.Count;

			return count;
		}

		public IList<string> GetNationalityOptionsList()
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var list = _selectElement.Options
				.Skip(1)
				.Select(option => option.Text)
				.ToList();

			return list;
		}

		public IList<string> GetNationalityNotInList(IList<string> nationalities)
		{
			_webDriverClient.WebDriverWait
				.WaitForElementToBeVisible(NationalityDropdownXPath);

			_selectElement = new SelectElement(NationalityDropdown);

			var options = _selectElement.Options
				.Skip(1)
				.Where(option => !nationalities.Contains(option.Text))
				.Select(option => option.Text)
				.ToList();

			return options;
		}

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
