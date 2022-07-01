using OrangeHRMTestingSuite.BusinessActions.Login;
using OrangeHRMTestingSuite.Interfaces;
using OrangeHRMTestingSuite.Models;
using TechTalk.SpecFlow;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.StepDefinitions.Login
{
	[Binding]
	public sealed class LoginStepDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriverClient _driverClient;
		private readonly LoginBusinessAction _loginBusinessAction;

		private IUser? _user;

		public LoginStepDefinition(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;
			
			_driverClient = (IWebDriverClient)_scenarioContext["WebDriverClient"];

			_loginBusinessAction = new LoginBusinessAction(_driverClient);
		}

		[Given(@"I log into the application with the user '([^']*)' and password '([^']*)'")]
		public void GivenILogIntoTheApplicationWithTheUserAndPassword(string username, string password)
		{
			_user = new User(username, password);
			
			_loginBusinessAction.Login(_user);

			_scenarioContext["User"] = _user;
		}
	}
}
