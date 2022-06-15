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

		private MyInfoBusinessAction? _myInfoBusinessAction;

		public MyInfoStepDefinition(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;

			_webDriverClient = (IWebDriverClient)_scenarioContext["WebDriverClient"];
		}

		[When(@"I reset the Nationality dropdown to the default option")]
		public void WhenIResetTheNationalityDropdownToTheDefaultOption()
		{
			var user = (IUser)_scenarioContext["User"];
			user.Nationality = string.Empty;

			_myInfoBusinessAction = new MyInfoBusinessAction(_webDriverClient);

			_myInfoBusinessAction.EditMyInfoForm();
			_myInfoBusinessAction.FillMyInfoForm(user);
			_myInfoBusinessAction.SaveMyInfoForm();
		}

		[Then(@"I save the changes to verify the Nationality dropdown is not required")]
		public void ThenISaveTheChangesToVerifyTheNationalityDropdownIsNotRequired()
		{
			_myInfoBusinessAction = new MyInfoBusinessAction(_webDriverClient);

			var isDisplayed = _myInfoBusinessAction.IsEditButtonDisplayed();

			Assert.That(
				isDisplayed, Is.True,
				"The Edit button is not displayed. The form was not saved.");
		}
	}
}
