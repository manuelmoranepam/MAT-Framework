using OpenQA.Selenium;

namespace OrangeHRMTestingSuite.PageObjects.Home
{
	public partial class HomePage
	{
		private string HomePageHeadingXPath => "//div[@id = 'content']//div/h1";
		private IWebElement HomePageHeading => _webDriver.FindElement(By.XPath(HomePageHeadingXPath));
	}
}
