using ConfigurationClient.Interfaces;
using Microsoft.Extensions.Configuration;

namespace ConfigurationClient.Classes
{
	public class ConfigurationReader : IConfigurationClient
	{
		private readonly IConfigurationBuilder _configurationBuilder;
		private readonly IConfiguration _configuration;
		private readonly string _fullFilePath;

		public ConfigurationReader(string filePath, string fileName, bool isOptional, bool reloadOnChange)
		{
			if (string.IsNullOrWhiteSpace(filePath))
				throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath));
			if (string.IsNullOrWhiteSpace(fileName))
				throw new ArgumentException($"'{nameof(fileName)}' cannot be null or whitespace.", nameof(fileName));

			_fullFilePath = SetupFullFilePath(filePath, fileName);

			_configurationBuilder = new ConfigurationBuilder()
				.AddJsonFile(_fullFilePath, isOptional, reloadOnChange);

			_configuration = _configurationBuilder.Build();
		}

		private string SetupFullFilePath(string filePath, string fileName)
		{
			var fullFilePath = Path.Combine(filePath, fileName);

			return fullFilePath;
		}

		public T GetValue<T>(string key)
		{
			if (string.IsNullOrWhiteSpace(key))
				throw new ArgumentException($"'{nameof(key)}' cannot be null or whitespace.", nameof(key));

			var value = (T)Convert.ChangeType(_configuration[key], typeof(T));

			return value;
		}

		public string GetConfigurationFileContent()
		{
			var fileContent = File.ReadAllText(_fullFilePath);

			if(string.IsNullOrWhiteSpace(fileContent))
				throw new ArgumentException($"'{nameof(fileContent)}' cannot be null or whitespace. Review the JSON configuration template.", nameof(fileContent));

			return fileContent;
		}
	}
}