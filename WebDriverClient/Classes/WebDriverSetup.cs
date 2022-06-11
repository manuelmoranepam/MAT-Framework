using Autofac;
using FacadeClient.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverClient.Enums;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace WebDriverClient.Classes
{
	public class WebDriverSetup
	{
		private readonly IFacadeClient _facadeClient;
		private readonly Browser _browser;
		private readonly IWebDriver _driver;

		public WebDriverSetup(IFacadeClient facadeClient, string configFilePath, string browserKey)
		{
			_facadeClient = facadeClient;

			_browser = GetBrowser(configFilePath, browserKey);
			
			_driver = LaunchWebDriver();
		}

		private Browser GetBrowser(string configFilePath, string browserKey)
		{
			var configuration = _facadeClient.ResolveConfigurationClient(configFilePath, false, true);

			var value = configuration.GetValue(browserKey);

			var browser = (Browser)Enum.Parse(typeof(Browser), value, true);

			return browser;
		}

		private IWebDriver LaunchWebDriver()
		{
			IWebDriver? driver;

			switch (_browser)
			{
				case Browser.Chrome:
					driver = LaunchChromeDriver();
					break;
				case Browser.Firefox:
					driver = LaunchFirefoxDriver();
					break;
				case Browser.Edge:
					driver = LaunchEdgeDriver();
					break;
				case Browser.HeadlessChrome:
					driver = LaunchHeadlessChromeDriver();
					break;
				case Browser.HeadlessFirefox:
					driver = LaunchHeadlessFirefoxDriver();
					break;
				case Browser.HeadlessEdge:
					driver = LaunchHeadlessEdgeDriver();
					break;
				default:
					driver = LaunchChromeDriver();
					break;
			}

			return driver;
		}

		private IWebDriver LaunchChromeDriver()
		{
			_ = new DriverManager().SetUpDriver(new ChromeConfig());

			var options = new ChromeOptions();
			options.AddArgument("--incognito");
			options.AddArgument("--no-default-browser-check");
			options.AddArgument("--ignore-certificate-errors-spki-list");

			var driver = new ChromeDriver(options);

			return driver;
		}

		private IWebDriver LaunchFirefoxDriver()
		{
			_ = new DriverManager().SetUpDriver(new FirefoxConfig());

			var options = new FirefoxOptions();
			options.AddArgument("--private");

			var driver = new FirefoxDriver(options);

			return driver;
		}

		private IWebDriver LaunchEdgeDriver()
		{
			_ = new DriverManager().SetUpDriver(new EdgeConfig());

			var options = new EdgeOptions();
			options.AddArgument("--inprivate");

			var driver = new EdgeDriver(options);

			return driver;
		}

		private IWebDriver LaunchHeadlessChromeDriver()
		{
			_ = new DriverManager().SetUpDriver(new ChromeConfig());

			var options = new ChromeOptions();
			options.AddArgument("--headless");
			options.AddArgument("--incognito");
			options.AddArgument("--no-default-browser-check");

			var driver = new ChromeDriver(options);

			return driver;
		}

		private IWebDriver LaunchHeadlessFirefoxDriver()
		{
			_ = new DriverManager().SetUpDriver(new FirefoxConfig());

			var options = new FirefoxOptions();
			options.AddArgument("--private");
			options.AddArgument("--headless");

			var driver = new FirefoxDriver(options);

			return driver;
		}

		private IWebDriver LaunchHeadlessEdgeDriver()
		{
			_ = new DriverManager().SetUpDriver(new EdgeConfig());

			var options = new EdgeOptions();
			options.AddArgument("--headless");
			options.AddArgument("--inprivate");

			var driver = new EdgeDriver(options);

			return driver;
		}
	}
}