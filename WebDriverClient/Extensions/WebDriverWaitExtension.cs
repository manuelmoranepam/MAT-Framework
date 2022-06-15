using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WebDriverClient.Extensions
{
	public static class WebDriverWaitExtension
	{
		public static void WaitForAlertToBeDisplayed(this WebDriverWait webDriverWait)
		{
			webDriverWait.Until(ExpectedConditions.AlertIsPresent());
		}

		public static void WaitForElementToExist(this WebDriverWait webDriverWait, string xpath)
		{
			if (string.IsNullOrWhiteSpace(xpath))
				throw new ArgumentException($"'{nameof(xpath)}' cannot be null or whitespace.", nameof(xpath));

			webDriverWait.Until(ExpectedConditions.ElementExists(By.XPath(xpath)));
		}

		public static void WaitForElementToBeVisible(this WebDriverWait webDriverWait, string xpath)
		{
			if (string.IsNullOrWhiteSpace(xpath))
				throw new ArgumentException($"'{nameof(xpath)}' cannot be null or whitespace.", nameof(xpath));

			webDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
		}

		public static void WaitForElementToBeClickable(this WebDriverWait webDriverWait, string xpath)
		{
			if (string.IsNullOrWhiteSpace(xpath))
				throw new ArgumentException($"'{nameof(xpath)}' cannot be null or whitespace.", nameof(xpath));

			webDriverWait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
		}

		public static void WaitForElementToBeStale(this WebDriverWait webDriverWait, IWebElement element)
		{
			if (element is null)
				throw new ArgumentNullException(nameof(element));

			webDriverWait.Until(ExpectedConditions.StalenessOf(element));
		}
	}
}
