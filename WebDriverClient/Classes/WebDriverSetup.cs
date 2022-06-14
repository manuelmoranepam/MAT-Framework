using Autofac;
using ConfigurationClient.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverClient.Enums;
using WebDriverClient.Interfaces;
using WebDriverClient.Models;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverClient.Classes
{
	public class WebDriverSetup : IWebDriverClient
	{
		private dynamic? _options;
		private IClock? _clock;
		private TimeSpan _pageLoadSeconds;
		private TimeSpan _implicitWaitSeconds;
		private TimeSpan _explicitWaitSeconds;
		private TimeSpan _sleepIntervalSeconds;

		private readonly string _baseUrl;
		private readonly FacadeClient _facadeClient;
		private readonly IDriverConfiguration _driverConfiguration;
		private readonly IConfigurationClient _configurationClient;
		private readonly IConfigurationFileInformation _configurationFileInformation;
		private readonly Browser _browser;
		private readonly IWebDriver _webDriver;
		private readonly WebDriverWait _webDriverWait;

		public WebDriverSetup(IContainer container, IConfigurationFileInformation configurationFileInformation)
		{
			if (container is null)
				throw new ArgumentNullException(nameof(container));
			if (configurationFileInformation is null)
				throw new ArgumentNullException(nameof(_configurationFileInformation));

			_facadeClient = new FacadeClient(container);

			_configurationFileInformation = configurationFileInformation;

			_configurationClient = SetupConfigurationClient();

			_driverConfiguration = SetupDriverConfiguration();

			_browser = SetupBrowser();

			_baseUrl = SetupBaseUrl();

			_webDriver = LaunchWebDriver();

			_webDriverWait = SetupWebDriverWait();
		}

		private IConfigurationClient SetupConfigurationClient()
		{
			var configurationReader = _facadeClient.ResolveConfigurationClient(
				_configurationFileInformation.FilePath,
				_configurationFileInformation.FileName,
				_configurationFileInformation.IsOptional,
				_configurationFileInformation.ReloadOnChange);

			return configurationReader;
		}

		private IDriverConfiguration SetupDriverConfiguration()
		{
			var configurationFileContent = _configurationClient.GetConfigurationFileContent();

			if (string.IsNullOrWhiteSpace(configurationFileContent))
				throw new ArgumentException($"'{nameof(configurationFileContent)}' cannot be null or whitespace.", nameof(configurationFileContent));

			var jsonResponse = _facadeClient.ResolveJsonResponseClient();
			var driverConfiguration = jsonResponse.DeserializeResponse<DriverConfiguration>(configurationFileContent);

			return driverConfiguration;
		}

		private Browser SetupBrowser()
		{
			var browser = _driverConfiguration.Browser;

			return browser;
		}

		private string SetupBaseUrl()
		{
			var baseUrl = _driverConfiguration.BaseUrl;

			return baseUrl;
		}

		private IWebDriver LaunchWebDriver()
		{
			var driver = _browser switch
			{
				Browser.Chrome => LaunchChromeDriver(),
				Browser.Firefox => LaunchFirefoxDriver(),
				Browser.Edge => LaunchEdgeDriver(),
				Browser.HeadlessChrome => LaunchHeadlessChromeDriver(),
				Browser.HeadlessFirefox => LaunchHeadlessFirefoxDriver(),
				Browser.HeadlessEdge => LaunchHeadlessEdgeDriver(),
				_ => LaunchChromeDriver(),
			};

			return driver;
		}

		private IWebDriver LaunchChromeDriver()
		{
			_ = new DriverManager().SetUpDriver(new ChromeConfig());

			_options = new ChromeOptions();
			_options.AddArgument("--incognito");
			_options.AddArgument("--no-default-browser-check");
			_options.AddArgument("--ignore-certificate-errors-spki-list");

			var driver = new ChromeDriver(_options);

			return driver;
		}

		private IWebDriver LaunchFirefoxDriver()
		{
			_ = new DriverManager().SetUpDriver(new FirefoxConfig());

			_options = new FirefoxOptions();
			_options.AddArgument("--private");

			var driver = new FirefoxDriver(_options);

			return driver;
		}

		private IWebDriver LaunchEdgeDriver()
		{
			_ = new DriverManager().SetUpDriver(new EdgeConfig());

			_options = new EdgeOptions();
			_options.AddArgument("--inprivate");

			var driver = new EdgeDriver(_options);

			return driver;
		}

		private IWebDriver LaunchHeadlessChromeDriver()
		{
			_ = new DriverManager().SetUpDriver(new ChromeConfig());

			_options = new ChromeOptions();
			_options.AddArgument("--headless");
			_options.AddArgument("--incognito");
			_options.AddArgument("--no-default-browser-check");

			var driver = new ChromeDriver(_options);

			return driver;
		}

		private IWebDriver LaunchHeadlessFirefoxDriver()
		{
			_ = new DriverManager().SetUpDriver(new FirefoxConfig());

			_options = new FirefoxOptions();
			_options.AddArgument("--private");
			_options.AddArgument("--headless");

			var driver = new FirefoxDriver(_options);

			return driver;
		}

		private IWebDriver LaunchHeadlessEdgeDriver()
		{
			_ = new DriverManager().SetUpDriver(new EdgeConfig());

			_options = new EdgeOptions();
			_options.AddArgument("--headless");
			_options.AddArgument("--inprivate");

			var driver = new EdgeDriver(_options);

			return driver;
		}

		private WebDriverWait SetupWebDriverWait()
		{
			SetupTimeouts();

			_clock = new SystemClock();

			var webDriverWait = new WebDriverWait(_clock, _webDriver, _explicitWaitSeconds, _sleepIntervalSeconds);

			return webDriverWait;
		}

		private void SetupTimeouts()
		{
			_pageLoadSeconds = _driverConfiguration.PageLoad;
			_implicitWaitSeconds = _driverConfiguration.ImplicitWait;
			_explicitWaitSeconds = _driverConfiguration.ExplicitWait;
			_sleepIntervalSeconds = _driverConfiguration.SleepInterval;

			_webDriver.Manage().Timeouts().PageLoad = _pageLoadSeconds;
			_webDriver.Manage().Timeouts().ImplicitWait = _implicitWaitSeconds;
		}

		public void NavigateToUrl()
		{
			_webDriver.Navigate().GoToUrl(_baseUrl);
		}

		public void NavigateToUrl(string url)
		{
			_webDriver.Navigate().GoToUrl(url);
		}

		public string GetCurrentUrl()
		{
			var url = _webDriver.Url;

			return url;
		}

		public void CloseBrowserTab()
		{
			_webDriver.Close();
		}

		public void QuitWebDriver()
		{
			_webDriver.Quit();
		}

		public void DisposeWebDriver()
		{
			_webDriver.Dispose();
		}

		public void TerminateWebDriver()
		{
			CloseBrowserTab();
			QuitWebDriver();
			DisposeWebDriver();
		}

		public IWebDriver GetInstanceOf()
		{
			return _webDriver;
		}
	}
}