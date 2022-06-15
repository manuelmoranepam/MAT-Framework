using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace WebDriverClient.Extensions
{
	public static class WebElementExtension
	{
		private static Actions? _actions;

		public static void HoverOver(this IWebElement element, IWebDriver driver)
		{
			_actions = new Actions(driver);

			_actions
				.MoveToElement(element)
				.Build()
				.Perform();
		}
	}
}
