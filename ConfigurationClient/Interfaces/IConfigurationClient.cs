namespace ConfigurationClient.Interfaces
{
	public interface IConfigurationClient
	{
		string GetValue(string key);
	}
}