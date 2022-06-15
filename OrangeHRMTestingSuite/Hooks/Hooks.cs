using Autofac;
using ConfigurationClient.Interfaces;
using FacadeService.Classes;
using JsonResponseClient.Interfaces;
using NUnit.Framework;
using OrangeHRMTestingSuite.Classes;
using TechTalk.SpecFlow;
using WebDriverClient.Interfaces;
using WebDriverClient.Models;

[assembly: Parallelizable(ParallelScope.Fixtures)]
namespace OrangeHRMTestingSuite.Hooks
{
	[Binding]
	public sealed class Hooks
	{
		private const string _configurationFileName = "appsettings.json";

		private static IContainer? _container;
		private static FacadeClient? _facadeClient;
		private static IConfigurationFileInformation? _configFileInfo;
		
		[BeforeTestRun]
		public static void BeforeTestRun()
		{
			_container = new ServiceSetup().GetInstanceOf();

			if (_container is null)
				throw new ArgumentNullException(nameof(_container));

			_facadeClient = new FacadeClient(_container);

			if (_facadeClient is null)
				throw new ArgumentNullException(nameof(_facadeClient));

			_configFileInfo = _facadeClient
				.ResolveConfigurationFileInformationClient(AppContext.BaseDirectory, _configurationFileName, false, false);

			if (_configFileInfo is null)
				throw new ArgumentNullException(nameof(_configFileInfo));
		}

		[BeforeFeature]
		public static void BeforeFeature(FeatureContext featureContext)
		{
			if (featureContext is null)
				throw new ArgumentNullException(nameof(featureContext));
		}

		[BeforeScenario]
		public static void BeforeScenario(ScenarioContext scenarioContext)
		{
			if (scenarioContext is null)
				throw new ArgumentNullException(nameof(scenarioContext));
			if (_facadeClient is null)
				throw new ArgumentNullException(nameof(_facadeClient));
			if (_container is null)
				throw new ArgumentNullException(nameof(_container));
			if (_configFileInfo is null)
				throw new ArgumentNullException(nameof(_configFileInfo));

			var webDriverClient = _facadeClient.ResolveWebDriverClient(_container, _configFileInfo);

			webDriverClient.NavigateToUrl();

			scenarioContext["WebDriverClient"] = webDriverClient;
		}

		[BeforeStep]
		public static void BeforeStep()
		{

		}

		[AfterStep]
		public static void AfterStep()
		{

		}

		[AfterScenario]
		public static void AfterScenario(ScenarioContext scenarioContext)
		{
			var webDriverClient = (IWebDriverClient)scenarioContext["WebDriverClient"];

			webDriverClient.TerminateWebDriver();
		}

		[AfterFeature]
		public static void AfterFeature(FeatureContext featureContext)
		{
			if (featureContext is null)
				throw new ArgumentNullException(nameof(featureContext));
		}

		[AfterTestRun]
		public static void AfterTestRun()
		{

		}
	}
}