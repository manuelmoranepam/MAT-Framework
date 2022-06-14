using Newtonsoft.Json;
using WebDriverClient.Enums;
using WebDriverClient.Interfaces;

namespace WebDriverClient.Models
{
	public class DriverConfiguration : IDriverConfiguration
	{
		[JsonProperty("Browser")]
		public Browser Browser { get; set; }
		
		[JsonProperty("BaseUrl")]
		public string BaseUrl { get; set; }
		
		[JsonProperty("PageLoad")]
		public TimeSpan PageLoad { get; set; }
		
		[JsonProperty("ImplicitWait")]
		public TimeSpan ImplicitWait { get; set; }
		
		[JsonProperty("ExplicitWait")]
		public TimeSpan ExplicitWait { get; set; }
		
		[JsonProperty("SleepInterval")]
		public TimeSpan SleepInterval { get; set; }
	}
}