using ConfigurationClient.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConfigurationClient.Classes
{
	public class ConfigurationReader : IConfigurationClient
	{
		private readonly IConfigurationBuilder _configurationBuilder;
		private readonly IConfiguration _configuration;

		public ConfigurationReader(string path, bool isOptional, bool reloadOnChange)
		{
			if (string.IsNullOrWhiteSpace(path))
				throw new ArgumentException($"'{nameof(path)}' cannot be null or whitespace.", nameof(path));

			_configurationBuilder = new ConfigurationBuilder()
				.AddJsonFile(path, isOptional, reloadOnChange);

			_configuration = _configurationBuilder.Build();
		}

		public string GetValue(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			var value = _configuration[key];

			return value;
		}
	}
}