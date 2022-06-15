using OrangeHRMTestingSuite.BusinessActions.Home;
using TechTalk.SpecFlow;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.StepDefinitions.Home
{
	[Binding]
	public sealed class NavBarStepDefinition
	{
		private readonly ScenarioContext _scenarioContext;
		private readonly IWebDriverClient _webDriverClient;

		private NavBarBusinessAction? _navBarBusinessAction;

		public NavBarStepDefinition(ScenarioContext scenarioContext)
		{
			_scenarioContext = scenarioContext;

			_webDriverClient = (IWebDriverClient)_scenarioContext["WebDriverClient"];
		}

		[When(@"I navigate to the My Info page")]
		public void WhenINavigateToTheMyInfoPage()
		{
			_navBarBusinessAction = new NavBarBusinessAction(_webDriverClient);

			_navBarBusinessAction.NavigateToMyInfoPage();
		}
	}
}
