using NUnit.Framework;
using OrangeHRMTestingSuite.BusinessActions.MyInfo;
using OrangeHRMTestingSuite.Interfaces;
using TechTalk.SpecFlow;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.StepDefinitions.MyInfo
{
	[Binding]
	public sealed class MyInfoStepDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriverClient _webDriverClient;
		private readonly MyInfoBusinessAction _myInfoBusinessAction;

		public MyInfoStepDefinition(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;

			_webDriverClient = (IWebDriverClient)_scenarioContext["WebDriverClient"];

			_myInfoBusinessAction = new MyInfoBusinessAction(_webDriverClient);
		}

		[When(@"I use my custom Select Element methods for the Nationality Dropdown")]
		public void WhenIUseMyCustomSelectElementMethodsForTheNationalityDropdown()
		{
			var user = (IUser)_scenarioContext["User"];

			_myInfoBusinessAction.EditMyInfoForm();
			_myInfoBusinessAction.FillMyInfoForm(user);
			_myInfoBusinessAction.SaveMyInfoForm();

			user.Nationality = _myInfoBusinessAction
				.GetStoredValues()
				.Nationality;

			_scenarioContext["User"] = user;
		}

		[Then(@"I save the changes to verify the Nationality dropdown saved my selected option")]
		public void ThenISaveTheChangesToVerifyTheNationalityDropdownSavedMySelectedOption()
		{
			var isDisplayed = _myInfoBusinessAction.IsEditButtonDisplayed();

			Assert.That(
				isDisplayed, Is.True,
				"The Edit button is not displayed. The form was not saved.");

			var expectedUser = (IUser)_scenarioContext["User"];
			var actualUser = _myInfoBusinessAction.GetStoredValues();

			Assert.That(
				actualUser.Nationality, Is.EqualTo(expectedUser.Nationality),
				$"The expected and actual nationalities are not equal. " +
				$"Expected: {expectedUser.Nationality}. " +
				$"Actual: {actualUser.Nationality}.");
		}
	}
}
