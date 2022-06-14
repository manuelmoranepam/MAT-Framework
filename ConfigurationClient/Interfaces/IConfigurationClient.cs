namespace ConfigurationClient.Interfaces
{
	public interface IConfigurationClient
	{
		string? GetConfigurationFileContent();
		T GetValue<T>(string key);
	}
}