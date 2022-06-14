namespace WebDriverClient.UnitTests.Classes
{
	[Parallelizable(ParallelScope.All)]
	public class WebDriverSetup_Tests
	{
		private const bool _isOptional = false;
		private const bool _reloadOnChange = false;

		private IContainer _container;
		private FacadeClient _facadeClient;

		[SetUp]
		public void Setup()
		{
			_container = new ServiceSetup().GetInstanceOf();
			_facadeClient = new FacadeClient(_container);
		}

		[TestCase("chromeconfig.json")]
		[TestCase("firefoxconfig.json")]
		[TestCase("edgeconfig.json")]
		[TestCase("headlesschromeconfig.json")]
		[TestCase("headlessfirefoxconfig.json")]
		[TestCase("headlessedgeconfig.json")]
		public void WebDriverSetup_WhenPassingCorrectParameters_BrowserIsLaunched(string fileName)
		{
			var configurationFileInformation = _facadeClient.ResolveConfigurationFileInformationClient(AppContext.BaseDirectory, fileName, _isOptional, _reloadOnChange);
			var webDriverClient = _facadeClient.ResolveWebDriverClient(_container, configurationFileInformation);
			
			var webDriver = webDriverClient.GetInstanceOf();
			var isNull = webDriver is null;

			webDriverClient.TerminateWebDriver();

			Assert.That(isNull, Is.Not.True);
		}

		[TestCase("chromeconfig.json", "Chrome")]
		[TestCase("firefoxconfig.json", "Firefox")]
		[TestCase("edgeconfig.json", "Edge")]
		[TestCase("headlesschromeconfig.json", "Chrome")]
		[TestCase("headlessfirefoxconfig.json", "Firefox")]
		[TestCase("headlessedgeconfig.json", "Edge")]
		public void WebDriverSetup_WhenPassingCorrectParameters_TheBrowserTypeIsCorrect(string fileName, string expectedBrowser)
		{
			var configurationFileInformation = _facadeClient.ResolveConfigurationFileInformationClient(AppContext.BaseDirectory, fileName, _isOptional, _reloadOnChange);
			var webDriverClient = _facadeClient.ResolveWebDriverClient(_container, configurationFileInformation);
			
			var webDriver = webDriverClient.GetInstanceOf();
			var actualBrowser = webDriver.GetType().Name;

			webDriverClient.TerminateWebDriver();

			Assert.That(
				expectedBrowser,
				Is.SubsetOf(actualBrowser),
				$"The expected type is not the same as the actual browser type. " +
				$"Expected: {expectedBrowser}. " +
				$"Actual: {actualBrowser}.");
		}

		[TestCase("chromeconfig.json")]
		[TestCase("firefoxconfig.json")]
		[TestCase("edgeconfig.json")]
		[TestCase("headlesschromeconfig.json")]
		[TestCase("headlessfirefoxconfig.json")]
		[TestCase("headlessedgeconfig.json")]
		public void NavigateToUrl_WhenCalled_BrowserNavigatesUrlFromConfigFile(string fileName)
		{
			var configurationClient = _facadeClient.ResolveConfigurationClient(AppContext.BaseDirectory, fileName, _isOptional, _reloadOnChange);
			var configurationFileContent = configurationClient.GetConfigurationFileContent();
			var jsonResponseClient = _facadeClient.ResolveJsonResponseClient();
			var driverConfiguration = jsonResponseClient.DeserializeResponse<DriverConfiguration>(configurationFileContent);
			var expectedUrl = driverConfiguration.BaseUrl;

			var configurationFileInformation = _facadeClient.ResolveConfigurationFileInformationClient(AppContext.BaseDirectory, fileName, _isOptional, _reloadOnChange);
			var webDriverClient = _facadeClient.ResolveWebDriverClient(_container, configurationFileInformation);
			webDriverClient.NavigateToUrl();
			var actualUrl = webDriverClient.GetCurrentUrl();

			webDriverClient.TerminateWebDriver();

			Assert.That(
				actualUrl, Is.EqualTo(expectedUrl),
				$"The expected and actual URLs are not equal. " +
				$"Expected: {expectedUrl}. " +
				$"Actual: {actualUrl}.");
		}

		[TestCase("chromeconfig.json", "https://www.microsoft.com/")]
		[TestCase("firefoxconfig.json", "https://www.microsoft.com/")]
		[TestCase("edgeconfig.json", "https://www.microsoft.com/")]
		[TestCase("headlesschromeconfig.json", "https://visualstudio.microsoft.com/")]
		[TestCase("headlessfirefoxconfig.json", "https://visualstudio.microsoft.com/")]
		[TestCase("headlessedgeconfig.json", "https://visualstudio.microsoft.com/")]
		public void NavigateToUrl_WhenPassingAValidUrl_BrowserNavigatesUrl(string fileName, string expectedUrl)
		{
			var configurationFileInformation = _facadeClient.ResolveConfigurationFileInformationClient(AppContext.BaseDirectory, fileName, _isOptional, _reloadOnChange);
			var webDriverClient = _facadeClient.ResolveWebDriverClient(_container, configurationFileInformation);
			
			webDriverClient.NavigateToUrl(expectedUrl);
			var actualUrl = webDriverClient.GetCurrentUrl();

			webDriverClient.TerminateWebDriver();

			Assert.That(
				expectedUrl, Is.SubsetOf(actualUrl),
				$"The expected URL is not contained in the actual URL. " +
				$"Expected: {expectedUrl}. " +
				$"Actual: {actualUrl}.");
		}

		[TearDown]
		public void TearDown()
		{
		}
	}
}