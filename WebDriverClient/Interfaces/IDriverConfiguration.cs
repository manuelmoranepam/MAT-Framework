using WebDriverClient.Enums;

namespace WebDriverClient.Interfaces
{
	public interface IDriverConfiguration
	{
		string BaseUrl { get; set; }
		Browser Browser { get; set; }
		TimeSpan ExplicitWait { get; set; }
		TimeSpan ImplicitWait { get; set; }
		TimeSpan PageLoad { get; set; }
		TimeSpan SleepInterval { get; set; }
	}
}