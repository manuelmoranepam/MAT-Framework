using OpenQA.Selenium;

namespace WebDriverClient.Interfaces
{
	public interface IWebDriverClient
	{
		void CloseBrowserTab();
		void DisposeWebDriver();
		string GetCurrentUrl();
		IWebDriver GetInstanceOf();
		void NavigateToUrl();
		void NavigateToUrl(string url);
		void QuitWebDriver();
		void TerminateWebDriver();
	}
}